/**
 * @file
 * @brief This file contains the definition of the AddUser class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System;
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

    if (isNull(userData.UserName) || userData.UserType == null || isNull(userData.Password))
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

    try {
      this.dbConnection.InsertUser(new User(userData.UserName,
            userData.Password, userData.UserType.Value));
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }
}
