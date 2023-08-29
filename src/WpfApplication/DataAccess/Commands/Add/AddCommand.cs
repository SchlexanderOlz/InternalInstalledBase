/**
 * @file
 * @brief This file contains the definition of the AddCommand abstract class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System;


/**
 * @brief AddComamnd definies the generall interface to all events which are raised on execute
 */
public abstract class AddCommand : DBCommand
{
  public event EventHandler<ErrorEventArgs>? AddFailed;
  public event EventHandler? AddSuccess;

  public static Func<string?, bool> isNull = string.IsNullOrEmpty;

  protected virtual void OnAddFailed(ErrorEventArgs e)
  {
    AddFailed?.Invoke(this, e);
  }

  protected virtual void OnAddSuccessfull()
  {
    AddSuccess?.Invoke(this, EventArgs.Empty);
  }
}
