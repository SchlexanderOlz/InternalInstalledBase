/**
 * @file
 * @brief This file contains the definition of the CheckUserExisting class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System;


/**
 * @brief The SubmitUser command is used to check is a user is contained in the
 * databse or not. Return the whole user if the credentials match
 */
public class CheckUsersExisting : DBCommand
{

  public event EventHandler UsersNonExistant;

  public CheckUsersExisting() : base() {}

  public override void Execute(object parameter)
  {
    if (this.dbConnection.AnyUsers())
    {
      this.OnUsersNonExistant();
    }
  }

  protected virtual void OnUsersNonExistant()
  {
    UsersNonExistant?.Invoke(this, EventArgs.Empty);
  }

}
