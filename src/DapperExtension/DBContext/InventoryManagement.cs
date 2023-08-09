using Microsoft.EntityFrameworkCore;

namespace DapperExtension.DBContext;
using Models;
using Models.Users;

public class InventoryManagementContext : DbContext
{

  public DbSet<Customer> Customers { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<SubjectArea> SubjectAreas { get; set; }
  public DbSet<Hardware> Hardware { get; set; }
  public DbSet<Software> Software { get; set; }
  public DbSet<User> Users { get; set; }

  #region ModelConnection
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseMySQL("server=localhost;port=7400;database=IIB;user=user;password=tmp");
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
    new DataChange().Up(modelBuilder);
    new Session().Up(modelBuilder);
    new Property().Up(modelBuilder);
    new Moderator().Up(modelBuilder);
  }

  #endregion
}


