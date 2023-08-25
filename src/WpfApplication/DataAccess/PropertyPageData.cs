namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class PropertyPageData : PageData<Property>
{
  public PropertyPageData() : base(new Save(), new AddProperty(),
      new SearchProperty(), new DeleteProperty())
  {

  }

}
