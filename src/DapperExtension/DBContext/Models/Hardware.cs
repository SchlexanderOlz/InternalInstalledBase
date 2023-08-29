/**
 * @file
 * @brief This file contains the definition of the Hardware class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;
public class Hardware : Descriptable
{
  public uint MaterialNumber { get; set; }
  public uint Ip { get; set; }
  public ICollection<Product>? Products { get; set; }

  public Hardware(string name, string description, string shortcut, uint ip, uint materialNumber)
    : base(name, description, shortcut)
  {
    this.Ip = ip;
    this.MaterialNumber = materialNumber;
  }
  internal Hardware() : base() { }

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
