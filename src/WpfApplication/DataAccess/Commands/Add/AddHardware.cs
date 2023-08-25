namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System;

public class AddHardware : AddCommand
{
  public AddHardware() : base() { }

  public override void Execute(object? param)
  {
    HardwareData? hardwareData = param as HardwareData;
    if (hardwareData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(HardwareData)}"));
      return;
    }

    if (isNull(hardwareData.Name) || isNull(hardwareData.Description) ||
        isNull(hardwareData.Shortcut) || !hardwareData.Ip.HasValue || !hardwareData.MaterialNumber.HasValue)
    {
      string msg = "Missing fields";
      if (isNull(hardwareData.Name))
      {
        msg += ", " + nameof(hardwareData.Name);
      }
      if (isNull(hardwareData.Description))
      {
        msg += ", " + nameof(hardwareData.Description);
      }
      if (isNull(hardwareData.Shortcut))
      {
        msg += ", " + nameof(hardwareData.Shortcut);
      }
      if (!hardwareData.Ip.HasValue)
      {
        msg += ", " + nameof(hardwareData.Ip);
      }
      if (!hardwareData.MaterialNumber.HasValue)
      {
        msg += ", " + nameof(hardwareData.MaterialNumber);
      }
      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }

    try {
      this.dbConnection.InsertHardware(new Hardware(hardwareData.Name,
            hardwareData.Description, hardwareData.Shortcut, hardwareData.Ip.Value,
            hardwareData.MaterialNumber.Value));
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }
}
