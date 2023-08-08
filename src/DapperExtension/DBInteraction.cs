namespace DapperExtension;

using DapperExtension.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
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

  public static ref DBInteraction GetInstance() {
    if (DBInteraction.dbInteraction == null) {
      DBInteraction.dbInteraction = new(); 
    } 
    return ref DBInteraction.dbInteraction;
  }

  #region InsertStatements
  public void InsertProduct(Product product)
  {
    this.context.GetProductDataSet().Add(product);
    this.context.SaveChanges();
  }

  public void InsertHardware(Hardware hardware)
  {
    this.context.GetHardwareDataSet().Add(hardware);
    this.context.SaveChanges();
  }

  public void InsertUser(User user)
  {
    this.context.GetUserDataSet().Add(user);
    this.context.SaveChanges();
  }
  #endregion

  #region SelectStatements
  public User? GetUserByCredentials(string username, string password)
  {
      string passwordHash = DBInteraction.HashPassword(in password);
      return this.context.GetUserDataSet()
          .Where(u => u.UserName == username && u.Password == passwordHash)
          .FirstOrDefault();
  }

  public ICollection<Customer> GetAllCustomers()
  {
    return this.context.GetCustomerDataSet().ToList();
  }

  public ICollection<Product> GetAllProducts()
  {
    return this.context.GetProductDataSet().ToList();
  }

  public ICollection<Hardware> GetAllHardware()
  {
    return this.context.GetHardwareDataSet().ToList();
  }

  public ICollection<Software> GetAllSoftware()
  {
    return this.context.GetSoftwareDataSet().ToList();
  }

  public Software GetSoftwareByParam(string? name, string? shortcut, string? description,
                                     uint? versionNumber)
  {
    return this.context.GetSoftwareDataSet()
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

  public static string HashPassword(in string password)
  {
    byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

    StringBuilder stringBuilder = new();
    foreach (byte b in hashedBytes)
    {
      stringBuilder.Append(b);
    }
    return stringBuilder.ToString();
  }

}
