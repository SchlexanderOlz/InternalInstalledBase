/**
 * @file
 * @brief This file contains the definition of the Customer class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;


public class Customer : Descriptable
{
  public int CustomerId { get; set; }
  public HelpDeskStatus DeskStatus { get; set; }
  public ICollection<Product> Products { get; set; }
  public ICollection<SubjectArea> SubjectAreas { get; set; }

  public Customer(string name, string description, string shortcut, HelpDeskStatus status)
    : base(name, description, shortcut)
  {
    this.DeskStatus = status;
  }

  internal Customer() : base() { }

  public override void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Customer>(entityBuilder =>
      {
        entityBuilder.HasKey(e => e.CustomerId);
        entityBuilder.Property(e => e.DeskStatus)
              .IsRequired();
        entityBuilder.HasMany(e => e.SubjectAreas)
              .WithMany(s => s.Customers);
        entityBuilder.HasMany(e => e.Products)
              .WithMany(p => p.Customers);
      }
      );
  }
}

