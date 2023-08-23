namespace DataAccess.Commands;

using DapperExtension.DBContext.Models.Users;

public class UserData {
  public string? UserName { get; set; }
  public string? Password { get; set; }
  public UserType? UserType { get; set; }
}
