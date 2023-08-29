/**
 * @file
 * @brief This file contains the definition of the AddCustomer class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System;


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

    string msg = "Missing fields";
    if (isNull(customerData.Name))
    {
      msg += ", " + nameof(customerData.Name);
      return;
    }
    if (isNull(customerData.Description))
    {
      msg += ", " + nameof(customerData.Description);
      return;
    }
    if (isNull(customerData.Shortcut))
    {
      msg += ", " + nameof(customerData.Shortcut);
      return;
    }
    OnAddFailed(new ErrorEventArgs(msg));

    try {
      this.dbConnection.InsertCustomer(new Customer(customerData.Name,
          customerData.Description, customerData.Shortcut, customerData.Status));
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }

}
