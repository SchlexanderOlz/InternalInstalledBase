namespace DataAccess.Commands;

using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchSubjectArea : SearchCommand<SubjectArea>
{
  public SearchSubjectArea() : base() { }

  public override void Execute(object? param)
  {
    SubjectAreaData? data = param as SubjectAreaData;
    if (data == null)
    {
      throw new InvalidOperationException($"Data passed was not {typeof(SubjectAreaData)}");
    }
    ICollection<SubjectArea> users = this.dbConnection.GetSubjectAreasByParam(data.Name, data.Customers);

    if (users.Count > 0)
    {
      OnSearchResult(new SearchResults<SubjectArea>(users));
    }
  }
}
