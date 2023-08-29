/**
 * @file
 * @brief This file contains the definition of the DBInteraction class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension;

using DapperExtension.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using DBContext.Models.Users;
using DBContext.Models;

/**
 * @brief DBInteraction contains all queries made to the database
 *    -> Singleton
 */
public class DBInteraction
{
  private readonly InventoryManagementContext context;
  private static DBInteraction? dbInteraction;

  private DBInteraction()
  {
    this.context = new InventoryManagementContext();
    this.context.Database.EnsureCreated();
  }

  public void SaveChanges()
  {
    this.context.SaveChanges();
  }

  /**
   * @brief Get's the one and only instance of the class
   */
  public static DBInteraction GetInstance()
  {
    if (DBInteraction.dbInteraction == null)
    {
      DBInteraction.dbInteraction = new();
    }
    return DBInteraction.dbInteraction;
  }

  // InsertStatements all save the changes after adding a specific object to a DbSet
  #region InsertStatements
  public void InsertProduct(Product product)
  {
    this.context.Products.Add(product);
    this.context.SaveChanges();
  }

  public void InsertOption(Option option)
  {
    this.context.Options.Add(option);
    this.context.SaveChanges();
  }

  /**
   * @brief Inserts a Property with it's options in one transaction
   */
  public void InsertPropertyOptionPack(Property property, ICollection<Option> options)
  {
    foreach(var option in options)
    {
      option.Property = property;
    }
    this.context.Properties.Add(property);
    this.context.Options.AddRange(options);
    this.SaveChanges();
  }

  public void InsertProperty(Property property)
  {
    this.context.Properties.Add(property);
    this.context.SaveChanges();
  }

  public void InsertSession(Session session)
  {
    this.context.Sessions.Add(session);
    this.context.SaveChanges();
  }

  public void InsertSubjectArea(SubjectArea subjectArea)
  {
    this.context.SubjectAreas.Add(subjectArea);
    this.context.SaveChanges();
  }

  public void InsertHardware(Hardware hardware)
  {
    this.context.Hardware.Add(hardware);
    this.context.SaveChanges();
  }

  public void InsertUser(User user)
  {
    this.context.Users.Add(user);
    this.context.SaveChanges();
  }

  public void InsertCustomer(Customer customer)
  {
    this.context.Customers.Add(customer);
    this.context.SaveChanges();
  }

  public void InsertSoftware(Software software)
  {
    this.context.Software.Add(software);
    this.context.SaveChanges();
  }
  #endregion

  #region SelectStatements
  /**
   * @brief Searches for a user 
   * @param username Username of the user
   * @param password Password as string from the user -> will be hashed on search 
   */
  public User? GetUserByCredentials(string username, string password)
  {
    byte[] passwordHash = User.HashPassword(password);
    return this.context.Users
        .Where(u => u.UserName == username && u.Password.SequenceEqual(passwordHash))
        .FirstOrDefault();
  }

  /**
   * @brief Adds all vaguely definied where queries to the given reference to a query
   * @param query The query which should be modified to search for Descriptables
   */
  private void buildQueryDescriptableSimilar<T>(ref IQueryable<T> query, string? name,
                                    string? shortcut, string? description)
  where T : Descriptable
  {
    if (!string.IsNullOrEmpty(name))
    {
      query = query.Where(descriptable => EF.Functions.Like(descriptable.Name, $"%{name}%"));
    }

    if (!string.IsNullOrEmpty(shortcut))
    {
      query = query.Where(descriptable => EF.Functions.Like(descriptable.Shortcut, $"%{shortcut}%"));
    }

    if (!string.IsNullOrEmpty(description))
    {
      query = query.Where(descriptable => EF.Functions.Like(descriptable.Description, $"%{description}%"));
    }
  }

  public ICollection<Customer> GetAllCustomers()
  {
    return this.context.Customers.ToList();
  }

  public ICollection<Product> GetAllProducts()
  {
    return this.context.Products.ToList();
  }

  public ICollection<Hardware> GetAllHardware()
  {
    return this.context.Hardware.ToList();
  }

  public ICollection<Software> GetAllSoftware()
  {
    return this.context.Software.ToList();
  }

  #endregion

  // SelectByParamStatements select data from the database which vaguely matches
  // the given parameters
  #region SelectByParamStatements

  public ICollection<Option> GetOptionsByParam(string? name, Property? property)
  {
    IQueryable<Option> query = this.context.Options.AsQueryable();

    if (name != null)
    {
      query = query.Where(o =>  EF.Functions.Like(o.OptionName, $"%{name}%"));
    }

    if (property != null)
    {
      query = query.Where(o => o.Property == property);
    }

    return query.ToList();
  }

  public ICollection<Property> GetPropertiesByParam(string? name, ICollection<string>? options,
      ICollection<Product>? products)
  {
    IQueryable<Property> query = this.context.Properties.AsQueryable();
    if (name != null)
    {
      query = query.Where(p => p.Name == name);
    }

    if (options != null)
    {
      query = query.Where(p => p.Options.Any(option => options.Contains(option.OptionName)));
    }

    if (products != null)
    {
      query = query.Where(p => p.ProductProperty.Any(pp => products.Contains(pp.Product)));
    }

    return query.ToList();
  }

  public ICollection<Software> GetSoftwareByParam(string? name, string? shortcut, string? description,
      uint? versionNumber)
  {
    IQueryable<Software> query = this.context.Software.AsQueryable();
    buildQueryDescriptableSimilar(ref query, name, shortcut, description);

    if (versionNumber.HasValue)
    {
      query.Where(software => software.Version == versionNumber);
    }
    return query.ToList();
  }

  public ICollection<Customer> GetCustomersByParam(string? name, string? shortcut,
      string? description, HelpDeskStatus? status)
  {
    IQueryable<Customer> query = this.context.Customers.AsQueryable();

    buildQueryDescriptableSimilar(ref query, name, shortcut, description);
    if (status.HasValue)
    {
      query = query.Where(customer => customer.DeskStatus == status);
    }

    return query.ToList();
  }


  public ICollection<SubjectArea> GetSubjectAreasByParam(string? name, ICollection<Customer>? customers)
  {

    IQueryable<SubjectArea> query = this.context.SubjectAreas.AsQueryable();

    if (name != null)
    {
      query = query.Where(subjectArea => EF.Functions.Like(subjectArea.Name, $"%{name}%"));
    }

    if (customers != null)
    {
      query = query.Where(subjectArea => subjectArea.Customers.Any(customer => customers.Contains(customer)));
    }
    return query.ToList();
  }


  public ICollection<Product> GetProductsByParam(string? name, string? shortcut,
    string? description, Hardware? hardware, Software? software)
  {

    IQueryable<Product> query = this.context.Products.AsQueryable();
    buildQueryDescriptableSimilar(ref query, name, shortcut, description);
    if (hardware != null)
    {
      query = query.Where(product => product.Hardware == hardware);
    }

    if (software != null)
    {
      query = query.Where(product => product.Software == software);
    }
    return query.ToList();
  }

  public ICollection<Hardware> GetHardwareByParam(string? name, string? shortcut,
    string? description, uint? ip, uint? materialNumber)
  {

    IQueryable<Hardware> query = this.context.Hardware.AsQueryable();
    buildQueryDescriptableSimilar(ref query, name, shortcut, description);
    if (ip != null)
    {
      query = query.Where(hardware => hardware.Ip == ip);
    }

    if (materialNumber != null)
    {
      query = query.Where(hardware => hardware.MaterialNumber == materialNumber);
    }
    return query.ToList();
  }

  public ICollection<User> GetUsersByParam(string? userName, UserType? type)
  {

    IQueryable<User> query = this.context.Users.AsQueryable();
    if (userName != null)
    {
      query = query.Where(user => user.UserName == userName);
    }

    if (type != null)
    {
      query = query.Where(user => user.UserType == type);
    }

    return query.ToList();
  }

  #endregion
  // Delete Queries always take a range of objects which will be deleted from the database
  #region DeleteQueries
  public void DeleteProperty(ICollection<Property> properties)
  {
    this.context.Properties.RemoveRange(properties);
    this.SaveChanges();
  }

  public void DeleteOptions(ICollection<Option> options)
  {
    this.context.Options.RemoveRange(options);
    this.SaveChanges();
  }

  public void DeleteSubjectAreas(ICollection<SubjectArea> subjectAreas)
  {
    this.context.SubjectAreas.RemoveRange(subjectAreas);
    this.SaveChanges();
  }

  public void DeleteCustomers(ICollection<Customer> customers)
  {
    this.context.Customers.RemoveRange(customers);
    this.SaveChanges();
  }

  public void DeleteHardware(ICollection<Hardware> hardware)
  {
    this.context.Hardware.RemoveRange(hardware);
    this.SaveChanges();
  }

  public void DeleteProducts(ICollection<Product> products)
  {
    this.context.Products.RemoveRange(products);
    this.SaveChanges();
  }

  public void DeleteUsers(ICollection<User> users)
  {
    this.context.Users.RemoveRange(users);
    this.SaveChanges();
  }

  public void DeleteSoftware(ICollection<Software> software)
  {
    this.context.Software.RemoveRange(software);
    this.SaveChanges();
  }
  #endregion
}
