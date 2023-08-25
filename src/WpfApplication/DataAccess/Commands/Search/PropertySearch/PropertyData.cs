namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class PropertyData : ISearchData
{
  public string? Name { get; set; }
  public string? Effect { get; set; }
  public ICollection<Product>? Products { get; set; }

  public void Clear()
  {
    this.Name = null;
    this.Effect = null;
    this.Products = null;
  }
}
