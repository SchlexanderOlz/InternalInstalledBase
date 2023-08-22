namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteHardware : DBCommand {
  
  public DeleteHardware() : base() {}

  public override void Execute(object param) {
    this.dbConnection.DeleteHardware((ICollection<Hardware>)param);
  }
  
}
