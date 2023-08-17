namespace DataAccess.Commands;

using System.Windows.Input;
using DapperExtension;
using DapperExtension.DBContext.Models;
using System.Windows;


public class Edit : DBCommand {
  
  public Edit() : base() {}

  public override void Execute(object? param) {
    this.dbConnection.SaveChanges();
  }
  
}
