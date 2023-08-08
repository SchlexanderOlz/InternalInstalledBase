namespace DataAccess.Commands;

using System;
using DapperExtension.DBContext.Models.Users;

public class LogonSuccessArgs : EventArgs {
  public User User { get; } 

  public LogonSuccessArgs(User user)
  {
    User = user;
  }
}
