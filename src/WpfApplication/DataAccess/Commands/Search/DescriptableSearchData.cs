/**
* @file
* @brief This file contains the definition of the DescriptableSearchData class
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;


public abstract class DescriptableSearchData : NamedSearchData, ISearchData
{
  public string? Description { get; set; }
  public string? Shortcut { get; set; }

  public virtual void Clear() {
    this.Description = null;
    this.Shortcut = null;
  }
}
