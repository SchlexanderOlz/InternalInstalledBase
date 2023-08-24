namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;

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

    if (hardwareData.Name == null || hardwareData.Description == null ||
        hardwareData.Shortcut == null || !hardwareData.Ip.HasValue || !hardwareData.MaterialNumber.HasValue)
    {
      string msg = "Missing fields";
      if (hardwareData.Name == null)
      {
        msg += ", " + nameof(hardwareData.Name);
      }
      if (hardwareData.Description == null)
      {
        msg += ", " + nameof(hardwareData.Description);
      }
      if (hardwareData.Shortcut == null)
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
    this.dbConnection.InsertHardware(new Hardware(hardwareData.Name,
          hardwareData.Description, hardwareData.Shortcut, hardwareData.Ip.Value,
          hardwareData.MaterialNumber.Value));
  }
}
