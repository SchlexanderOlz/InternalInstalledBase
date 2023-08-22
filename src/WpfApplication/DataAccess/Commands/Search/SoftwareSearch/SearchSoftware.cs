namespace DataAccess.Commands;

using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchSoftware : SearchCommand<Software> {
  public SearchSoftware() : base() {}

  public override void Execute(object? param) {
    SoftwareData? data = param as SoftwareData;
    if (data == null) {
      throw new InvalidOperationException($"Data passed was not {typeof(SoftwareData)}");
    }
    ICollection<Software> products = this.dbConnection.GetSoftwareByParam(
        data.Name, data.Shortcut, data.Description, data.Version); 

    if (products.Count > 0) {
      OnSearchResult(new SearchResults<Software>(products));
    }
  }
}