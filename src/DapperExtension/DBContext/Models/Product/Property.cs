namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;

public class Property : IDataObject
{
  public int PropertyId { get; set; }
  public string Name { get; set; }
  public string Effect { get; set; }
  public ICollection<Product>? Products { get; set; }

  public void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Property>(entityBuilder =>
    {
      entityBuilder.HasKey(e => e.PropertyId);
      entityBuilder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(100);
      entityBuilder.Property(e => e.Effect)
        .IsRequired()
        .HasMaxLength(600);
    });
  }
}
