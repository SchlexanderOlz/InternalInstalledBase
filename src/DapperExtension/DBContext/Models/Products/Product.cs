namespace DapperExtension.DBContext.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Product : Descriptable
{
    public int ProductId { get; set; }
    public override void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.ProductId);
        });
    }
}