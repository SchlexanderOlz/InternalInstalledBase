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
        data?.Name, data?.Options?.Split(";"), data?.Products);

    OnSearchResult(new SearchResults<Property>(properties));
  }
}
