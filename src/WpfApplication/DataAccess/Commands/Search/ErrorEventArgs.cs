namespace DataAccess.Commands;

using System;

public class ErrorEventArgs : EventArgs {
  public string Message { get; }

  public ErrorEventArgs(string message) {
    this.Message = message;
  }
}
