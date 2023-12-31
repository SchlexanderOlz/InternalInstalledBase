/**
 * @file
 * @brief This file contains the definition of the AddSubjectArea class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System;


public class AddSubjectArea : AddCommand
{
  public AddSubjectArea() : base() { }

  public override void Execute(object? param)
  {
    SubjectAreaData? userData = param as SubjectAreaData;
    if (userData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(SubjectAreaData)}"));
      return;
    }

    if (isNull(userData.Name) || userData.Customers == null)
    {
      string msg = "Missing fields";
      if (userData.Name == null)
      {
        msg += ", " + nameof(userData.Name);
      }

      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }

    try
    {
      this.dbConnection.InsertSubjectArea(new SubjectArea(userData.Name, userData.Customers));
      OnAddSuccessfull();
    }
    catch (InvalidOperationException e)
    {
      OnAddFailed(new ErrorEventArgs(e.Message));
    }
  }
}
