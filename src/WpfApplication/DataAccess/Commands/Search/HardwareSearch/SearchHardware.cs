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
        data?.Name, data?.Shortcut, data?.Description, data?.Ip, data?.MaterialNumber);

    if (hardware.Count > 0)
    {
      OnSearchResult(new SearchResults<Hardware>(hardware));
    }
  }
}
