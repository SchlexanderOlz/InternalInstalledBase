namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class SubjectAreaData : NamedSearchData, ISearchData
{
  public ICollection<Customer>? Customers { get; set; }

  public void Clear()
  {
    this.Customers = null;
  }
}
