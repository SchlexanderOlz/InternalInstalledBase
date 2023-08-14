namespace DataAccess.Commands;

using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;
using DapperExtension;


public class SearchCustomer : ICommand {
  private readonly DBInteraction dbConnection;

  public event EventHandler SearchCustomerResultIn; 

  public SearchCustomer() {
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
    CustomerData? data = param as CustomerData;
    if (data == null) {
      throw new InvalidOperationException($"Data passed was not {typeof(CustomerData)}");
    }
    ICollection<Customer> customers = this.dbConnection.GetCustomersByParam(
        data.Name, data.Shortcut, data.Description, data.Status); 

    if (customers.Count > 0) {
      OnSearchResult(new SearchResultsInArgs(customers));
    }
  }

  protected virtual void OnSearchResult(SearchResultsInArgs args) {
    SearchCustomerResultIn?.Invoke(this, args); 
  }
}
