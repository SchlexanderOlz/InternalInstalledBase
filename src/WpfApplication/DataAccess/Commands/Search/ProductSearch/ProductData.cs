namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System.Collections.Generic;

public class ProductData : DescriptableSearchData {
  public Software? Software { get; set; }
  public Hardware? Hardware { get; set; }
  public ICollection<Customer>? Customers { get; set; }
}
