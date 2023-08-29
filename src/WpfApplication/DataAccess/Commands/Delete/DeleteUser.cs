/**
 * @file
 * @brief This file contains the definition of the DeleteUser class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models.Users;

public class DeleteUser : DBCommand
{

  public DeleteUser() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteUsers((ICollection<User>)param);
  }

}
