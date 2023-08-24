namespace WpfApplication;

using DapperExtension.DBContext.Models.Users;
using UserControls;
using System;

public class UserContentFactory
{

  public UserContent CreateUserContent(Session session)
  {
    switch (session.User.UserType)
    {
      case UserType.User:
        return new UserContent(session);
      case UserType.Moderator:
        return new ModeratorContent(session);
      case UserType.Admin:
        return new AdminContent(session);
      default:
        throw new InvalidOperationException("No Window for User found");
    }
  }
}
