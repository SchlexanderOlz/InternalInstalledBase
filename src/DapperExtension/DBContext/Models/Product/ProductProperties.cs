namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;


public class ProductProperty : IDataObject {
  public int ProductPropertyId { get; set; }
  public Product Product { get; set; }
  public Property Property { get; set; }
  public ICollection<Models.Option> SetOptions { get; set; }

  public void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ProductProperty>(entityBuilder => {
        entityBuilder.HasKey(p => p.ProductPropertyId);
        entityBuilder.HasMany(p => p.SetOptions)
          .WithMany(o => o.ProductProperties); 
        });
  }
}
