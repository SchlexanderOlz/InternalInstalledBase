using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DapperExtension.DBContext;
using Models;
using Models.Products;
using Models.Users;

public class InventoryManagementContext : DbContext
{

  public DbSet<Customer> Customers { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<SubjectArea> SubjectAreas { get; set; }
  public DbSet<Hardware> Hardwares { get; set; }
  public DbSet<Software> Softwares { get; set; }
  public DbSet<User> Users { get; set; }

  public InventoryManagementContext() : base()
  {

  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseMySQL("server=localhost;port=7400;database=IIB;user=user;password=tmp");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    new SubjectArea().Up(modelBuilder);
    new Hardware().Up(modelBuilder);
    new Customer().Up(modelBuilder);
    new Software().Up(modelBuilder);
    new Product().Up(modelBuilder);
    new VCB().Up(modelBuilder);
    new User().Up(modelBuilder);
  }


}
