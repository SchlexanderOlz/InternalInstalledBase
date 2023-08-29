/**
 * @file
 * @brief This file contains the definition of the Product class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;


public class Product : Descriptable
{
  public int ProductId { get; set; }
  public Software Software { get; set; }
  public Hardware Hardware { get; set; }
  public ICollection<Customer>? Customers { get; set; }
  public ICollection<ProductProperty>? Properties { get; set; }

  public Product(string name, string description, string shortcut, Hardware hardware,
      Software software) : base(name, description, shortcut)
  {
    this.Software = software;
    this.Hardware = hardware;
  }
  internal Product() : base() { }

  public override void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>(entityBuilder =>
    {
      entityBuilder.HasKey(e => e.ProductId);
      entityBuilder.HasOne(e => e.Software)
            .WithMany(s => s.Products);
      entityBuilder.HasOne(e => e.Hardware)
            .WithMany(h => h.Products);
      entityBuilder.HasMany(e => e.Customers)
            .WithMany(c => c.Products);
      entityBuilder.HasMany(e => e.Properties)
            .WithOne(p => p.Product);
    });
  }
}
