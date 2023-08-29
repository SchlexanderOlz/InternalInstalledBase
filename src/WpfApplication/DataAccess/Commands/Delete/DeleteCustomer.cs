/**
 * @file
 * @brief This file contains the definition of the DeleteCustomer class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteCustomer : DBCommand
{

  public DeleteCustomer() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteCustomers((ICollection<Customer>)param);
  }

}
