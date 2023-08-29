/**
 * @file
 * @brief This file contains the definition of the DeleteProduct class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteProduct : DBCommand
{

  public DeleteProduct() : base() { }

  public override void Execute(object param)
  {
    this.dbConnection.DeleteProducts((ICollection<Product>)param);
  }

}
