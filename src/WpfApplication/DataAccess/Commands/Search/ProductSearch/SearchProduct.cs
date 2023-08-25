namespace DataAccess.Commands;

using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchProduct : SearchCommand<Product>
{
  public SearchProduct() : base() { }

  public override void Execute(object? param)
  {
    ProductData? data = param as ProductData;
    ICollection<Product> products = this.dbConnection.GetProductsByParam(
        data?.Name, data?.Shortcut, data?.Description, data?.Hardware, data?.Software);

    if (products.Count > 0)
    {
      OnSearchResult(new SearchResults<Product>(products));
    }
  }
}
