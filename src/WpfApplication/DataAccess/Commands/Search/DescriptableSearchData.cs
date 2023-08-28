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
