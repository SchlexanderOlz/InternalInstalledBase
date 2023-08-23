namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class SubjectAreaData {
  public string? Name { get; set; }
  public ICollection<Customer>? Customers { get; set; }
}
