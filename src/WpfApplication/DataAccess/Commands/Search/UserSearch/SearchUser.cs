namespace DataAccess.Commands;

using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models.Users;


public class SearchUser : SearchCommand<User> {
  public SearchUser() : base() {}

  public override void Execute(object? param) {
    UserData? data = param as UserData;
    if (data == null) {
      throw new InvalidOperationException($"Data passed was not {typeof(SoftwareData)}");
    }
    ICollection<User> users = this.dbConnection.GetUsersByParam(
        data.UserName, data.UserType); 

    if (users.Count > 0) {
      OnSearchResult(new SearchResults<User>(users));
    }
  }
}
