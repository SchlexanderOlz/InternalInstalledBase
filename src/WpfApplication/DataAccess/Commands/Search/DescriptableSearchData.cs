namespace DataAccess.Commands;


public class DescriptableSearchData : ISearchData
{
  public string? Name { get; set; }
  public string? Description { get; set; }
  public string? Shortcut { get; set; }

  public virtual void Clear() {
    this.Name = null;
    this.Description = null;
    this.Shortcut = null;
  }
}
