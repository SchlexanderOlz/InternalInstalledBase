/**
* @file
* @brief This file contains the definition of the SearchSoftware class
* @author Alexander Scholz
* @date 29-08-2023
*/
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
        data?.Name, data?.Shortcut, data?.Description, data?.Version, null);

    OnSearchResult(new SearchResults<Software>(products));
  }
}
