namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;


public class OptionData : NamedSearchData, ISearchData
{
  public Property? Property { get; set; }

  public void Clear()
  {
    this.Property = null;
  }
}
