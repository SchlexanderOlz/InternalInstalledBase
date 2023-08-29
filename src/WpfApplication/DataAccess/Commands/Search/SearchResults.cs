/**
* @file
* @brief This file contains the definition of the SearchResults class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using System.Collections.Generic;

public class SearchResults<T>
{
  public SearchResults(ICollection<T> data)
  {
    this.Data = data;
  }
  public ICollection<T> Data;
}
