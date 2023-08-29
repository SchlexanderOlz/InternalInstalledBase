/**
* @file
* @brief This file contains the definition of the UserPageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models.Users;

public class UserPageData : PageData<User>
{
  public UserPageData() : base(new Save(), new AddUser(),
      new SearchUser(), new DeleteUser())
  {

  }

}
