/**
 * @file
 * @brief This file contains the definition of the SearchCustomer class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchCustomer : SearchCommand<Customer>
{

  public SearchCustomer() : base() { }

  public override void Execute(object param)
  {
    CustomerData? data = param as CustomerData;

    ICollection<Customer> customers = this.dbConnection.GetCustomersByParam(
        data?.Name, data?.Shortcut, data?.Description, data?.Status);

    OnSearchResult(new SearchResults<Customer>(customers));
  }

}
