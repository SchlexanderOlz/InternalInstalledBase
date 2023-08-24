namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class SoftwarePageData : PageData<Software>
{
  public SoftwarePageData() : base(new Save(), new AddSoftware(),
      new SearchSoftware(), new DeleteSoftware())
  {

  }

}
