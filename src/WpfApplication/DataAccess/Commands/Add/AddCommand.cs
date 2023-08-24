namespace DataAccess.Commands;

using System;

public abstract class AddCommand : DBCommand
{
  public event EventHandler<ErrorEventArgs> AddFailed;

  protected virtual void OnAddFailed(ErrorEventArgs e)
  {
    AddFailed?.Invoke(this, e);
  }
}
