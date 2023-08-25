namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class SubjectAreaData : ISearchData
{
  public string? Name { get; set; }
  public ICollection<Customer>? Customers { get; set; }

  public void Clear()
  {
    this.Name = null;
    this.Customers = null;
  }
}
