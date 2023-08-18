namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;

public class Product : Descriptable
{
  public int ProductId { get; set; }
  public Software Software { get; set; }
  public Hardware Hardware { get; set; }
  public ICollection<Customer> Customers { get; set; }
  public ICollection<Property> Properties { get; set; }

  public Product(string name, string description, string shortcut) : base(name, description, shortcut) {}
  internal Product() : base() {}

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
            .WithMany(p => p.Products);
    });
  }
}
