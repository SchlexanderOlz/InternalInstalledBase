/**
 * @file
 * @brief This file contains the definition of the SearchProduct class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

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

    OnSearchResult(new SearchResults<Product>(products));
  }
}
