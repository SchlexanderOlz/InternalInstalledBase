/**
* @file
* @brief This file contains the definition of the SearchCommand abstract class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using System;


/**
 * @brief The SearchCommand class defines the generall events raised by this command
 */
public abstract class SearchCommand<T> : DBCommand
{
  public event EventHandler<SearchResults<T>> SearchResultIn;

  protected virtual void OnSearchResult(SearchResults<T> args)
  {
    SearchResultIn?.Invoke(this, args);
  }
}
