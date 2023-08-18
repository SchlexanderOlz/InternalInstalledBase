namespace DataAccess.Commands;

using System.Collections.Generic;

public class SearchResults<T> {
  public SearchResults(ICollection<T> data)
  {
    this.Data = data;
  }
  public ICollection<T> Data;
}
