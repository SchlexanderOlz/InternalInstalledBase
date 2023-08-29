/**
 * @file
 * @brief This file contains the definition of the OptionData class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
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
