namespace DataAccess.Commands;

using DapperExtension.DBContext.Models.Users;

public class AddSession : AddCommand
{
  public AddSession() : base() { }

  public override void Execute(object param)
  {
    Session session = (Session)param;
    this.dbConnection.InsertSession(session);
  }
}
