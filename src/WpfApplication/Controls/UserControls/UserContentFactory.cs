namespace WpfApplication;

using DapperExtension.DBContext.Models.Users;
using UserControls;
using System;

public class UserContentFactory {

  public UserContent CreateUserContent(User user) {
      switch (user.UserType) {
        case UserType.User:
          return new UserContent(user);
        case UserType.Moderator:
          return new ModeratorContent(user);
        case UserType.Admin:
          return new AdminContent(user);
        default:
          throw new InvalidOperationException("No Window for User found");
      }
  }
}
