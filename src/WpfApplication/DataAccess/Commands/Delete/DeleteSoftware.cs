/**
 * @file
 * @brief This file contains the definition of the DeleteSoftware class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteSoftware : DBCommand
{

  public DeleteSoftware() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteSoftware((ICollection<Software>)param);
  }

}
