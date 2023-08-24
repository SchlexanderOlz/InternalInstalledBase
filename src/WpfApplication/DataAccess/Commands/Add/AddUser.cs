namespace DataAccess.Commands;

using DapperExtension.DBContext.Models.Users;


public class AddUser : AddCommand
{
  public AddUser() : base() { }

  public override void Execute(object? param)
  {
    UserData? userData = param as UserData;
    if (userData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(UserData)}"));
      return;
    }

    if (userData.UserName == null || userData.UserType == null ||
      userData.Password == null)
    {
      string msg = "Missing fields";
      if (userData.UserName == null)
      {
        msg += ", " + nameof(userData.UserName);
      }
      if (userData.Password == null)
      {
        msg += ", " + nameof(userData.Password);
      }
      if (userData.UserType == null)
      {
        msg += ", " + nameof(userData.UserType);
      }
      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }
    this.dbConnection.InsertUser(new User(userData.UserName,
          userData.Password, userData.UserType.Value));
  }
}
