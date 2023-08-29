/**
 * @file
 * @brief This file contains the definition of the AddSoftware class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System;


public class AddSoftware : AddCommand
{
  public AddSoftware() : base() { }

  public override void Execute(object? param)
  {
    SoftwareData? softwareData = param as SoftwareData;
    if (softwareData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(CustomerData)}"));
      return;
    }

    if (isNull(softwareData.Name) || isNull(softwareData.Description) ||
      softwareData.Version == null || isNull(softwareData.Shortcut))
    {
      string msg = "Missing fields";
      if (softwareData.Name == null)
      {
        msg += ", " + nameof(softwareData.Name);
      }
      if (softwareData.Description == null)
      {
        msg += ", " + nameof(softwareData.Description);
      }
      if (softwareData.Shortcut == null)
      {
        msg += ", " + nameof(softwareData.Shortcut);
      }
      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }

    try {
      this.dbConnection.InsertSoftware(new Software(softwareData.Name,
            softwareData.Description, softwareData.Shortcut, softwareData.Version.Value));
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }
}
