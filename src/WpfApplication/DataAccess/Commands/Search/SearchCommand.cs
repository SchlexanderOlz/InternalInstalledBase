namespace DataAccess.Commands;

using System;

public abstract class SearchCommand<T> : DBCommand
{
  public event EventHandler<SearchResults<T>> SearchResultIn; 

  protected virtual void OnSearchResult(SearchResults<T> args) {
    SearchResultIn?.Invoke(this, args); 
  }
}
