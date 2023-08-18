namespace DataAccess.Commands;

using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;
using DapperExtension;


public class SearchProduct : DBCommand {
  public event EventHandler<ProductSearchResults> SearchProductResultIn; 

  public SearchProduct() : base() {}

  public override void Execute(object param) {
    ProductData? data = param as ProductData;
    if (data == null) {
      throw new InvalidOperationException($"Data passed was not {typeof(ProductData)}");
    }
    ICollection<Product> products = this.dbConnection.GetProductsByParam(
        data.Name, data.Shortcut, data.Description, data.Hardware, data.Software); 

    if (products.Count > 0) {
      OnSearchResult(new ProductSearchResults(products));
    }
  }

  protected virtual void OnSearchResult(ProductSearchResults args) {
    SearchProductResultIn?.Invoke(this, args); 
  }
}
