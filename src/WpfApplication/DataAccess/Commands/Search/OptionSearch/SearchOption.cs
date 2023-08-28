namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchOption : SearchCommand<Option>
{
  public SearchOption() : base() { }

  public override void Execute(object? param)
  {
    OptionData? data = param as OptionData;
    ICollection<Option> properties = this.dbConnection.GetOptionsByParam(
        data?.Name, data?.Property);

    OnSearchResult(new SearchResults<Option>(properties));
  }
}
