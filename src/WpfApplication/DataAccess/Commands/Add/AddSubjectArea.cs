namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;


public class AddSubjectArea : AddCommand {
  public AddSubjectArea() : base() {}

  public override void Execute(object? param) {
    SubjectAreaData? userData = param as SubjectAreaData;
    if (userData == null) {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(SubjectAreaData)}"));
      return;
    }

    if (userData.Name == null) {
      string msg = "Missing fields";
      if (userData.Name == null) {
        msg += ", " + nameof(userData.Name);
      }

      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }
    this.dbConnection.InsertSubjectArea(new SubjectArea(userData.Name));
  }
}
