/**
 * @file
 * @brief This file contains the definition of the SubmitUser class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System;
using System.Windows;
using DapperExtension.DBContext.Models.Users;


/**
 * @brief The SubmitUser command is used to check is a user is contained in the
 * databse or not. Return the whole user if the credentials match
 */
public class SubmitUser : DBCommand
{

  public event EventHandler<Session> LogonSuccess;
  public event EventHandler LogonFailure;

  public SubmitUser() : base() {}

  public override void Execute(object parameter)
  {
    UserCredentials logonData = (UserCredentials)parameter;

    try
    {
      this.dbConnection.GetUserByCredentials(logonData.Username, logonData.Password);
    }
    catch (Exception e)
    {
      MessageBox.Show(e.Message);
    }
    User? user = this.dbConnection.GetUserByCredentials(logonData.Username, logonData.Password);
    if (user != null)
    {
      Session session = new(user);
      session.Start();
      OnLogonSuccess(session);
    }
    else
    {
      OnLogonFailure();
    }
  }

  protected virtual void OnLogonSuccess(Session args)
  {
    LogonSuccess?.Invoke(this, args);
  }

  protected virtual void OnLogonFailure()
  {
    LogonFailure?.Invoke(this, EventArgs.Empty);
  }
}
