namespace DapperExtension.DBContext;

using Microsoft.EntityFrameworkCore;
using Models;
using Models.Users;
using DapperExtension.Config;

public class InventoryManagementContext : DbContext
{

  private const string CONFIG_PATH = "../../../../DapperExtension/dbconfig.yml"; 
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<SubjectArea> SubjectAreas { get; set; }
  public DbSet<Hardware> Hardware { get; set; }
  public DbSet<Software> Software { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Session> Sessions { get; set; }

  #region ModelConnection
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string data = ConfigParser.GetConnectionData(CONFIG_PATH);
    optionsBuilder.UseMySQL(data);
  }

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
  }

  #endregion
}


