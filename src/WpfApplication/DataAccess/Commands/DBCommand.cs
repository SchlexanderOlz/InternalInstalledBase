namespace DataAccess.Commands;

using System.Windows.Input;
using System;
using DapperExtension;

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
