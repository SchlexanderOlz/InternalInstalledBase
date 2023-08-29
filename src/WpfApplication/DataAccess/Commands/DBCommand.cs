/**
* @file
* @brief This file contains the definition of the DBCommand abstract class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using System.Windows.Input;
using System;
using DapperExtension;


/**
 * @brief The DBCommad is the generall interface for a command which performs
 * an action on the database. It holds a db-connection object as a field
 */
public abstract class DBCommand : ICommand
{

  public virtual event EventHandler CanExecuteChanged
  {
    add { CommandManager.RequerySuggested += value; }
    remove { CommandManager.RequerySuggested -= value; }
  }
  protected DBInteraction dbConnection;

  public DBCommand() : base()
  {
    this.dbConnection = DBInteraction.GetInstance();
  }
  public abstract void Execute(object? param);
  public virtual bool CanExecute(object? param)
  {
    return true;
  }

}
