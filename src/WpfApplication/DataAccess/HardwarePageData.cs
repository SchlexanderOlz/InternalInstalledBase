namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class HardwarePageData : PageData<Hardware>
{
  public HardwarePageData() : base(new Save(), new AddHardware(),
      new SearchHardware(), new DeleteHardware())
  {

  }

}
