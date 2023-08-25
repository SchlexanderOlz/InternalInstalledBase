namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteProperty : DBCommand
{

  public DeleteProperty() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteProperty((ICollection<Property>)param);
  }

}
