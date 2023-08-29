/**
 * @file
 * @brief This file contains the definition of the UserContentFactory class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using DapperExtension.DBContext.Models.Users;
using UserControls;
using System;


/**
 * @brief The UserContentFactory is used to create new ContentPages
 */
public class UserContentFactory
{
  /**
   * @brief Creates a new userContent depending on the parameter given
   * @param session session object of the newly input user
   */
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
