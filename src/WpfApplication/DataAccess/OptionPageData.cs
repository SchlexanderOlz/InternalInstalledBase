namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class OptionPageData : PageData<Option>
{
  public OptionPageData() : base(new Save(), new AddOption(),
      new SearchOption(), new DeleteOption())
  {

  }

}
