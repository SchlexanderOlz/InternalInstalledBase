/**
* @file
* @brief This file contains the definition of the HardwarePageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
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
