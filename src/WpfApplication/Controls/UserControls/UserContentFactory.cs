namespace WpfApplication;

using DapperExtension.DBContext.Models;
using DapperExtension.DBContext.Models.Users;
using UserControls;
using System;

public class UserContentFactory {

  public UserContent CreateUserContent(User user) {
      switch (user.UserType) {
        case UserType.kUser:
          return new UserContent(user);
        case UserType.kModerator:
          return new ModeratorContent(user);
        case UserType.kAdmin:
          return new AdminContent(user);
        default:
          throw new InvalidOperationException("No Window for User found");
      }
  }
}
