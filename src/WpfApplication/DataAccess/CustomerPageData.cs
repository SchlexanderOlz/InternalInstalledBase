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
  public Edit Edit { get; set; }
  public ObservableCollection<Customer> Customers { get; set; }

  public CustomerPageData() {
    this.SearchCustomer = new(); 
    this.Customers = new();
    this.AddCustomer = new();
    this.Edit = new();
    this.SearchCustomer.SearchCustomerResultIn += displaySearch; 
    this.AddCustomer.AddFailed += displayError;
  }
  
  private void displaySearch(object sender, SearchResultsInArgs args) {
    this.Customers.Clear();
    foreach(var customer in args.Customers) {
      this.Customers.Add(customer);
    }
  }

  private void displayError(object sender, ErrorEventArgs args) {
    MessageBox.Show(args.Message);
  }
}
