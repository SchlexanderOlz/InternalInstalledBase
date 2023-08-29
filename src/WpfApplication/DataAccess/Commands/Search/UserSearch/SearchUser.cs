/**
* @file
* @brief This file contains the definition of the SearchUser class
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models.Users;


public class SearchUser : SearchCommand<User>
{
  public SearchUser() : base() { }

  public override void Execute(object? param)
  {
    UserData? data = param as UserData;
    ICollection<User> users = this.dbConnection.GetUsersByParam(
        data?.UserName, data?.UserType);

    OnSearchResult(new SearchResults<User>(users));
  }
}
