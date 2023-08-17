namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;
using System.Windows;
using WpfApplication.Pages;
using System;


public partial class AdminContent : ModeratorContent {
  public AdminContent(User user) : base(user) {
    var userButton = new Button { Content = "Users" };
    this.NavBar.Controls.Add(userButton);
  }

  protected void loadUserPage(object sender, RoutedEventArgs args) {
    // Load user Page
  }

  protected override void loadCustomerPage(object sender, RoutedEventArgs e) {
    AdminCustomerPage page = new AdminCustomerPage(this.user);
    appendToGrid(page);
    try {
      page.InitializeComponent();
    } catch (Exception ex) {
      MessageBox.Show(ex.ToString());
    }
  }
}
