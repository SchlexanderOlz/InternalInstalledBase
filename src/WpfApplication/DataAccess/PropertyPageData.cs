/**
* @file
* @brief This file contains the definition of the PropertyPageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
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
