/**
 * @file
 * @brief This file contains the definition of the AddSession class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models.Users;
using System;

public class AddSession : AddCommand
{
  public AddSession() : base() { }

  public override void Execute(object param)
  {
    Session session = (Session)param;

    try {
      this.dbConnection.InsertSession(session);
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }
}
