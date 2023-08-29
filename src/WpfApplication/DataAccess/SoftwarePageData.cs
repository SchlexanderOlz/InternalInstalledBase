/**
* @file
* @brief This file contains the definition of the SoftwarePageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
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
