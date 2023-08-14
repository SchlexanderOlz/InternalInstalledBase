namespace DataAccess.Commands;

using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;
using DapperExtension;


public class AddCustomer : ICommand {
  private DBInteraction dbConnection;

  public AddCustomer() {
    this.dbConnection = DBInteraction.GetInstance();
  }

  public bool CanExecute(object param) {
    return true;
  }

  public event EventHandler CanExecuteChanged
  {
    add { CommandManager.RequerySuggested += value; }
    remove { CommandManager.RequerySuggested -= value; }
  }

  public void Execute(object param) {
    CustomerData? customerData = param as CustomerData;
    if (customerData == null) {
      throw new InvalidOperationException("Invalid object passed to execute");
    }

    if (customerData.Name == null || customerData.Description == null || customerData.Shortcut == null) {
      throw new InvalidOperationException("All values need to be supplied for the customer");
    }
    this.dbConnection.InsertCustomer(new Customer(customerData.Name,
          customerData.Description, customerData.Shortcut, customerData.Status));
  }

}
