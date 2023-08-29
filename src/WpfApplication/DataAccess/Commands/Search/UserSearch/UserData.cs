/**
* @file
* @brief This file contains the definition of the UserData class
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models.Users;

public class UserData : ISearchData
{
  public string? UserName { get; set; }
  public string? Password { get; set; }
  public UserType? UserType { get; set; }

  public void Clear()
  {
    this.UserName = null;
    this.Password = null;
    this.UserType = null;
  }
}
