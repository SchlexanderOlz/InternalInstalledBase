namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;

public class ProductData : DescriptableSearchData {
  public Software? Software { get; set; }
  public Hardware? Hardware { get; set; }
}
