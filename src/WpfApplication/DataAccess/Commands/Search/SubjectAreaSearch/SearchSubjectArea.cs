namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchSubjectArea : SearchCommand<SubjectArea>
{
  public SearchSubjectArea() : base() { }

  public override void Execute(object? param)
  {
    SubjectAreaData? data = param as SubjectAreaData;
    ICollection<SubjectArea> users = this.dbConnection.GetSubjectAreasByParam(data?.Name, data?.Customers);

    OnSearchResult(new SearchResults<SubjectArea>(users));
  }
}
