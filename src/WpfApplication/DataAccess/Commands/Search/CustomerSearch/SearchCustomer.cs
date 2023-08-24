namespace DataAccess.Commands;

using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchCustomer : SearchCommand<Customer>
{

  public SearchCustomer() : base() { }

  public override void Execute(object param)
  {
    CustomerData? data = param as CustomerData;
    if (data == null)
    {
      throw new InvalidOperationException($"Data passed was not {typeof(CustomerData)}");
    }
    ICollection<Customer> customers = this.dbConnection.GetCustomersByParam(
        data.Name, data.Shortcut, data.Description, data.Status);

    if (customers.Count > 0)
    {
      OnSearchResult(new SearchResults<Customer>(customers));
    }
  }

}
