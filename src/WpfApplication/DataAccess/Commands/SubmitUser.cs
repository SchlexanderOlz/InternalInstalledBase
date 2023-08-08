namespace DataAccess.Commands; 

using System.Windows.Input;
using System;
using DapperExtension;
using DapperExtension.DBContext.Models.Users;

public class SubmitUser : ICommand {

  private static SubmitUser? submitUser;
  private SubmitUser() {}

  public static SubmitUser GetInstance() {
    if (SubmitUser.submitUser == null) {
      SubmitUser.submitUser = new();
    }
    return SubmitUser.submitUser;
  }

  public bool CanExecute(object parameter)
  {
    return true;
  }

  public void Execute(object parameter)
  {
    UserLogonData logonData = parameter as UserLogonData;
    if (logonData == null) {
      throw new InvalidOperationException("Execute function was not passed valid UserDatvalid UserDataa");
    }
    User? user = DBInteraction.GetInstance().GetUserByCredentials(logonData.username, logonData.password);

    if (user != null) {
      OnLogonSuccess(new LogonSuccessArgs(user));
    } else {
      OnLogonFailure();
    }
  }

  public event EventHandler CanExecuteChanged
  {
    add { CommandManager.RequerySuggested += value; }
    remove { CommandManager.RequerySuggested -= value; }
  }

  public event EventHandler LogonSuccess;

  protected virtual void OnLogonSuccess(LogonSuccessArgs args)
  {
    LogonSuccess?.Invoke(this, args);
  }

  public event EventHandler LogonFailure;

  protected virtual void OnLogonFailure()
  {
    LogonFailure?.Invoke(this, EventArgs.Empty);
  }
}
