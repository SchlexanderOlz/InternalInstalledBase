namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;

public class Software : Descriptable
{
    public int SoftwareID { get; set; }
    public uint Version { get; set; }

    public override void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Software>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.SoftwareID);
            entityBuilder.Property(e => e.Version).IsRequired();
        }
        );
    }
}