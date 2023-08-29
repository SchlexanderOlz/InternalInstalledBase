/**
 * @file
 * @brief This file contains the definition of the Descriptable abstract class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;


public abstract class Descriptable : IDataObject
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Shortcut { get; set; }

  public Descriptable(string name, string description, string shortcut)
  {
    this.Name = name;
    this.Description = description;
    this.Shortcut = shortcut;
  }

  internal Descriptable() : base() { }

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
