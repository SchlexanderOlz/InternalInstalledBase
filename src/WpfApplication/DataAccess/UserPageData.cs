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
