namespace DataAccess;

using Commands;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using System.Windows;

public class CustomerPageData : IPageData {

  public SearchCustomer SearchCustomer { get; set; } 
  public AddCustomer AddCustomer { get; set; }
  public ObservableCollection<Customer> Customers { get; set; }

  public CustomerPageData() {
    this.SearchCustomer = new(); 
    this.Customers = new();
    this.AddCustomer = new();
    this.SearchCustomer.SearchCustomerResultIn += displaySearch; 
  }
  
  private void displaySearch(object sender, EventArgs e) {
    SearchResultsInArgs? args = e as SearchResultsInArgs;
    if (args == null) {
      throw new InvalidOperationException($"Event-Arg was not {typeof(SearchResultsInArgs)}");
    }
    foreach(var customer in args.Customers) {
      this.Customers.Add(customer);
    }
  }
}
