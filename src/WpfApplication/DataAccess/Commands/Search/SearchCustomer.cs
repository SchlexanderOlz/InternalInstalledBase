namespace DataAccess.Commands;

using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;
using DapperExtension;


public class SearchCustomer : DBCommand {
  public event EventHandler<SearchResultsInArgs> SearchCustomerResultIn; 

  public SearchCustomer() : base() {}


  public override void Execute(object param) {
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
