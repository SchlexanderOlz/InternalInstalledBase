/**
 * @file
 * @brief This file contains the definition of the ProductProperty class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;

using Microsoft.EntityFrameworkCore;


/**
 * @brief ProductProperty is a table which should help with the connection of
 * the Prduct and Property tables
 */
public class ProductProperty : IDataObject {
  // This field can be removed
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
