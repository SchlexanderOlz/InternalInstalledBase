namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;
public class Hardware : Descriptable
{
    public uint MaterialNumber { get; set; }
    public uint Ip { get; set; }
    public ICollection<Product>? Products { get; set; }

    public override void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hardware>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.MaterialNumber);
            entityBuilder.Property(e => e.Ip)
              .IsRequired();
        }
        );
    }

}
