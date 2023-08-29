/**
* @file
* @brief This file contains the definition of the ErrorEventArgs class
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using System;

public class ErrorEventArgs : EventArgs
{
  public string Message { get; }

  public ErrorEventArgs(string message)
  {
    this.Message = message;
  }
}
