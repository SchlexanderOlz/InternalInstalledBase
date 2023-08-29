/**
 * @file
 * @brief This File contains the definition of the InventoryManagementContext class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext;

using Microsoft.EntityFrameworkCore;
using Models;
using Models.Users;
using DapperExtension.Config;

/**
 * @brief InventoryManagementContext is responsible for managing all tables and 
 * connection of the database
 */
public class InventoryManagementContext : DbContext
{

  // NOTE: This is a relative path from wherever the programm is executed
  private const string CONFIG_PATH = "../DapperExtension/dbconfig.yml"; 
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<SubjectArea> SubjectAreas { get; set; }
  public DbSet<Hardware> Hardware { get; set; }
  public DbSet<Software> Software { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Session> Sessions { get; set; }
  public DbSet<Property> Properties { get; set; }
  public DbSet<Option> Options { get; set; }
  public DbSet<ProductProperty> ProductProperties { get; set; }

  #region ModelConnection
  /**
   * @brief Connects to the database with the configuration specified at *CONFIG_PATH*
   */
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string data = ConfigParser.GetConnectionData(CONFIG_PATH);
    optionsBuilder.UseMySQL(data);
  }

  /**
   * @brief Calls the Up method of all Database-Objects
   *  -> Configures database tables as specified in the Up method
   */
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    new SubjectArea().Up(modelBuilder);
    new Hardware().Up(modelBuilder);
    new Software().Up(modelBuilder);
    new Product().Up(modelBuilder);
    new Customer().Up(modelBuilder);
    new User().Up(modelBuilder);
    new Session().Up(modelBuilder);
    new Property().Up(modelBuilder);
    new Option().Up(modelBuilder);
    new ProductProperty().Up(modelBuilder); 
  }
  #endregion
}

