namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;


public class SearchProperty : SearchCommand<Property>
{
  public SearchProperty() : base() { }

  public override void Execute(object? param)
  {
    PropertyData? data = param as PropertyData;
    ICollection<Property> properties = this.dbConnection.GetPropertiesByParam(
        data?.Name, data?.Effect, data?.Products);

    if (properties.Count > 0)
    {
      OnSearchResult(new SearchResults<Property>(properties));
    }
  }
}
