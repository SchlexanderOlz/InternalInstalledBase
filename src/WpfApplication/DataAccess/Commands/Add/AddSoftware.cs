namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;


public class AddSoftware : AddCommand {
  public AddSoftware() : base() {}

  public override void Execute(object? param) {
    SoftwareData? softwareData = param as SoftwareData;
    if (softwareData == null) {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(CustomerData)}"));
      return;
    }

    if (softwareData.Name == null || softwareData.Description == null ||
      softwareData.Version == null || softwareData.Shortcut == null) {
      string msg = "Missing fields";
      if (softwareData.Name == null) {
        msg += ", " + nameof(softwareData.Name);
      }
      if (softwareData.Description == null) {
        msg += ", " + nameof(softwareData.Description);
      }
      if (softwareData.Shortcut == null) {
        msg += ", " + nameof(softwareData.Shortcut);
      }
      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }
    this.dbConnection.InsertSoftware(new Software(softwareData.Name,
          softwareData.Description, softwareData.Shortcut, softwareData.Version.Value));
  }
}
