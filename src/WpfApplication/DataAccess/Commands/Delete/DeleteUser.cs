namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models.Users;

public class DeleteUser : DBCommand {
  
  public DeleteUser() : base() {}

  public override void Execute(object param) {
    this.dbConnection.DeleteUsers((ICollection<User>)param);
  }
  
}
