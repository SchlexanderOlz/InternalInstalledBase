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
