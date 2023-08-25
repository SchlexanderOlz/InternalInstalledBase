namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;

public class Property : IDataObject
{
  public int PropertyId { get; set; }
  public string Name { get; set; }
  public string Effect { get; set; }
  // Work on this options next-time
  public ICollection<string> Options { get; set; }
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
      entityBuilder.Property(e => e.Options);
    });
  }
}
