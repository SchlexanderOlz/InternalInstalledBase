namespace DapperExtension;

using DapperExtension.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using DBContext.Models.Users;
using DBContext.Models;

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

  public static DBInteraction GetInstance()
  {
    if (DBInteraction.dbInteraction == null)
    {
      DBInteraction.dbInteraction = new();
    }
    return DBInteraction.dbInteraction;
  }

  #region InsertStatements
  public void InsertProduct(Product product)
  {
    this.context.Products.Add(product);
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
  public User? GetUserByCredentials(string username, string password)
  {
    byte[] passwordHash = User.HashPassword(password);
    return this.context.Users
        .Where(u => u.UserName == username && u.Password.SequenceEqual(passwordHash))
        .FirstOrDefault();
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


  public ICollection<SubjectArea> GetSubjectAreasByParam(string? name, ICollection<Customer> customers)
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
  #region DeleteQueries

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

  public void Log(DataChange change)
  {
    
  }


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

}
