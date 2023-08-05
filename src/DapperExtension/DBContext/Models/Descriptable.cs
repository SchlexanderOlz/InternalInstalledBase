namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Descriptable : IDataObject
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Shortcut { get; set; }

  public virtual void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Descriptable>(entityBuilder =>
    {
      entityBuilder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50);
      entityBuilder.Property(e => e.Description)
        .IsRequired()
        .HasMaxLength(600);
      entityBuilder.Property(e => e.Shortcut)
        .IsRequired()
        .HasMaxLength(10);
    });
  }
}