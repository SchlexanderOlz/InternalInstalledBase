namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchSoftware : SearchCommand<Software>
{
  public SearchSoftware() : base() { }

  public override void Execute(object? param)
  {
    SoftwareData? data = param as SoftwareData;
    ICollection<Software> products = this.dbConnection.GetSoftwareByParam(
        data?.Name, data?.Shortcut, data?.Description, data?.Version);

    OnSearchResult(new SearchResults<Software>(products));
  }
}
