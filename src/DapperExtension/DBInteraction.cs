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

  public Software GetSoftwareByParam(string? name, string? shortcut, string? description,
                                     uint? versionNumber)
  {
    return this.context.Software
            .Where(software => isDecriptableSimilar(software, name, shortcut, description)
                  || software.Version == versionNumber)
            .First();
  }
  #endregion

  private bool isDecriptableSimilar(Descriptable evaluator, string? name,
                                    string? shortcut, string? descritpion)
  {
    return EF.Functions.Like(evaluator.Name, $"%{name}%")
                || EF.Functions.Like(evaluator.Shortcut, $"%{shortcut}%")
                || EF.Functions.Like(evaluator.Description, $"%{descritpion}%");
  }

}
