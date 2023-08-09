namespace DapperExtension.DBContext.Models.Users;

class Admin : Moderator
{
  public Admin(string name, string password, UserType userType) : base(name, password, userType) {}
  public Admin() : base() {}
}
