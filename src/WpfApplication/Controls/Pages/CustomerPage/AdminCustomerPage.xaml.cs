namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using System.Windows;

public partial class AdminCustomerPage : ModeratorCustomerPage {

  public AdminCustomerPage(User user) : base(user) {}
}

