using Microsoft.EntityFrameworkCore;

namespace DapperExtension.DBContext;
using Models;
using Models.Users;

public class InventoryManagementContext : DbContext
{

  private DbSet<Customer> customers;
  private DbSet<Product> products;
  private DbSet<SubjectArea> subjectAreas;
  private DbSet<Hardware> hardware;
  private DbSet<Software> software;
  private DbSet<User> users;

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

  #region GettersSetters

  internal DbSet<Customer> GetCustomerDataSet()
  {
    return this.customers;
  }

  internal DbSet<Hardware> GetHardwareDataSet()
  {
    return this.hardware;
  }

  internal DbSet<Software> GetSoftwareDataSet()
  {
    return this.software;
  }

  internal DbSet<User> GetUserDataSet()
  {
    return this.users;
  }

  internal DbSet<Product> GetProductDataSet()
  {
    return this.products;
  }

  internal DbSet<SubjectArea> GetSubjectAreaSet()
  {
    return this.subjectAreas;
  }

  #endregion
}


