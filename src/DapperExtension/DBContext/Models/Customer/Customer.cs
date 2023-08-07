namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;


public class Customer : Descriptable
{
    public int CustomerId { get; set; }
    public HelpDeskStatus DeskStatus { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<SubjectArea> SubjectAreas { get; set; }

    public override void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entityBuilder =>
          {
              entityBuilder.HasKey(e => e.CustomerId);
              entityBuilder.Property(e => e.DeskStatus)
                .IsRequired();
              entityBuilder.HasMany(e => e.SubjectAreas)
                .WithOne()
                .HasForeignKey(e => e.SubjectAreaId);
              entityBuilder.HasMany(e => e.Products)
                .WithMany(p => p.Customers);
          }
          );
    }
}

