/**
 * @file
 * @brief This file contains the definition of the SearchHardware class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchHardware : SearchCommand<Hardware>
{
  public SearchHardware() : base() { }

  public override void Execute(object? param)
  {
    HardwareData? data = param as HardwareData;
    ICollection<Hardware> hardware = this.dbConnection.GetHardwareByParam(
        data?.Name, data?.Shortcut, data?.Description, data?.Ip, data?.MaterialNumber,
        null);

    OnSearchResult(new SearchResults<Hardware>(hardware));
  }
}
