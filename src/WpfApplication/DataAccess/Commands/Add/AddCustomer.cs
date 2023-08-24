namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System.Windows;


public class AddCustomer : AddCommand
{
  public AddCustomer() : base() { }

  public override void Execute(object param)
  {
    CustomerData? customerData = param as CustomerData;
    if (customerData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(CustomerData)}"));
      return;
    }

    if (customerData.Name == null || customerData.Description == null || customerData.Shortcut == null)
    {
      string msg = "Missing fields";
      if (customerData.Name == null)
      {
        msg += ", " + nameof(customerData.Name);
      }
      if (customerData.Description == null)
      {
        msg += ", " + nameof(customerData.Description);
      }
      if (customerData.Shortcut == null)
      {
        msg += ", " + nameof(customerData.Shortcut);
      }
      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }
    this.dbConnection.InsertCustomer(new Customer(customerData.Name,
          customerData.Description, customerData.Shortcut, customerData.Status));
  }

}
