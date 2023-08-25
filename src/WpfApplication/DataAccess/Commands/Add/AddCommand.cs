namespace DataAccess.Commands;

using System;

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
