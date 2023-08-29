/**
* @file
* @brief This file contains the definition of the SearchSubjectArea class
* @author Alexander Scholz
* @date 29-08-2023
*/
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
