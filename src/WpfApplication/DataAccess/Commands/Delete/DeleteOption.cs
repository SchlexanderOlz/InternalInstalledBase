namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteOption : DBCommand
{

  public DeleteOption() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteOptions((ICollection<Option>)param);
  }

}
