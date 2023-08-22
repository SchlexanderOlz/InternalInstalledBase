namespace DataAccess.Commands; 

using System.Windows.Input;
using System;
using System.Windows;
using DapperExtension;
using DapperExtension.DBContext.Models.Users;

public class SubmitUser : DBCommand {

  public event EventHandler<LogonSuccessArgs> LogonSuccess;
  public event EventHandler LogonFailure;

  public SubmitUser() : base() {}

  public override void Execute(object parameter)
  {
    UserCredentials? logonData = parameter as UserCredentials;
    if (logonData == null) {
      throw new InvalidOperationException("Execute function was not passed valid UserDatvalid UserDataa");
    }
    var dbInteraction = DBInteraction.GetInstance();
    try {
     dbInteraction.GetUserByCredentials(logonData.Username, logonData.Password);   
    } catch (Exception e) {
      MessageBox.Show(e.Message);
    }
    User? user = dbInteraction.GetUserByCredentials(logonData.Username, logonData.Password);
    if (user != null) {
      OnLogonSuccess(new LogonSuccessArgs(user));
    } else {
      OnLogonFailure();
    }
  }

  protected virtual void OnLogonSuccess(LogonSuccessArgs args)
  {
    LogonSuccess?.Invoke(this, args);
  }

  protected virtual void OnLogonFailure()
  {
    LogonFailure?.Invoke(this, EventArgs.Empty);
  }
}
