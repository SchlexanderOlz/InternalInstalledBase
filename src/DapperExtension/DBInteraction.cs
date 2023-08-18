namespace DapperExtension;

using DapperExtension.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
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

  public void SaveChanges() {
    this.context.SaveChanges();
  }

  public static DBInteraction GetInstance() {
    if (DBInteraction.dbInteraction == null) {
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

  public void InsertCustomer(Customer customer) {
    this.context.Customers.Add(customer);
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
    isDecriptableSimilar(ref query, name, shortcut, description);

    if (versionNumber.HasValue) {
      query.Where(software => software.Version == versionNumber);
    }
    return query.ToList();
  }

public ICollection<Customer> GetCustomersByParam(string? name, string? shortcut,
    string? description, HelpDeskStatus? status)
{
    IQueryable<Customer> query = this.context.Customers.AsQueryable();

    isDecriptableSimilar(ref query, name, shortcut, description);
    if (status.HasValue)
    {
        query = query.Where(customer => customer.DeskStatus == status);
    }

    return query.ToList();
  }

  public ICollection<Product> GetProductsByParam(string? name, string? shortcut,
    string? description, Hardware? hardware, Software? software) {

  }

  #endregion
  #region DeleteQueries
  public void DeleteCustomers(ICollection<Customer> customers) {
    this.context.Customers.RemoveRange(customers); 
    this.SaveChanges();
  }
  #endregion

  private void isDecriptableSimilar<T>(ref IQueryable<T> query, string? name,
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
