namespace DapperExtension.DBContext.Models.Products;
using Microsoft.EntityFrameworkCore;

public class VCB : Product
{
    public bool Seperator { get; set; }

    public FrameType FrameType { get; set; }
    public override void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VCB>(entityBuilder =>
        {
            entityBuilder.Property(e => e.Seperator)
                .IsRequired();
            entityBuilder.Property(e => e.FrameType)
                .IsRequired();
        });
    }
}

public enum FrameType
{
    kGreen,
    kRedOrSmth
}