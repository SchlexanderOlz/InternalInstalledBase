namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;

public class Property : IDataObject
{
  public int PropertyId { get; set; }
  public string Name { get; set; }
  public bool IsMultipleChoice { get; set; }
  public ICollection<Option> Options { get; set; }
  public ICollection<ProductProperty> ProductProperty { get; set; }

  public Property(string name, bool isMultipleChoice)
  {
    this.Name = name;
    this.IsMultipleChoice = isMultipleChoice;
  }

  internal Property() {}


  public void SetOptions(ICollection<Option> options)
  {
    this.Options = options;
  }

  public void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Property>(entityBuilder =>
    {
      entityBuilder.HasKey(e => e.PropertyId);
      entityBuilder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(100);
      entityBuilder.Property(e => e.IsMultipleChoice)
        .IsRequired();
      entityBuilder.HasMany(e => e.Options)
        .WithOne(o => o.Property);
      entityBuilder.HasMany(e => e.ProductProperty)
        .WithOne(p => p.Property);
    });
  }
}
