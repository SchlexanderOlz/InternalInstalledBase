namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteSubjectArea : DBCommand
{

  public DeleteSubjectArea() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteSubjectAreas((ICollection<SubjectArea>)param);
  }

}
