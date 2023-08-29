/**
* @file
* @brief This file contains the definition of the OptionPageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
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
