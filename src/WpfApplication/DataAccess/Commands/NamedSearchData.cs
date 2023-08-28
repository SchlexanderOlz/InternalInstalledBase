namespace DataAccess.Commands;

public abstract class NamedSearchData 
{
  public string? Name { get; set; }

  public void Clean()
  {
    this.Name = null;
  }
}
