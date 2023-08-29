/**
 * @file
 * @brief This file contains the definition of the Software class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;


public class Software : Descriptable
{
  public int SoftwareID { get; set; }
  public uint Version { get; set; }
  public ICollection<Product> Products { get; set; }

  public Software(string name, string description, string shortcut, uint version)
    : base(name, description, shortcut)
  {
    this.Version = version;
  }

  internal Software() : base() { }

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
