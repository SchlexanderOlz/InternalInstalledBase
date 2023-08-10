namespace DataAccess.Commands;

using System;
using DapperExtension.DBContext.Models;
using System.Collections.Generic;

public class SearchResultsInArgs : EventArgs {
  public ICollection<Customer> Customers { get; }

  public SearchResultsInArgs(ICollection<Customer> customers)
  {
    this.Customers = customers;
  }
}
