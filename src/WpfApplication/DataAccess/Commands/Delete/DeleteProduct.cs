namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class DeleteProduct : DBCommand {
  
  public DeleteProduct() : base() {}

  public override void Execute(object param) {
    this.dbConnection.DeleteProducts((ICollection<Product>)param);
  }
  
}
