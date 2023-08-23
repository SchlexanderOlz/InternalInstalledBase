namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;
using System.Windows;
using WpfApplication.Pages;


public partial class AdminContent : ModeratorContent {
  public AdminContent(User user) : base(user) {
    Button userButton = new Button { Content = "Users" };

    userButton.Click += loadUserPage;
    this.NavBar.Controls.Add(userButton);
  }

  protected void loadUserPage(object sender, RoutedEventArgs args) {
    UserPage page = new UserPage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }
}
