namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;

public class Option : IDataObject
{
  public int OptionId { get; set; }
  public string OptionName { get; set; }
  public Property Property { get; set; }
  public ICollection<ProductProperty> ProductProperties { get; set; }

  public Option(string name)
  {
    this.OptionName = name;
  }

  public Option(string name, Property property)
  {
    this.OptionName = name;
    this.Property = property;
  }

  internal Option() {}

  public void Up(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Option>(entityBuilder => {
        entityBuilder.HasKey(o => o.OptionId);
        entityBuilder.Property(o => o.OptionName)
          .IsRequired();
    });
  }
}
