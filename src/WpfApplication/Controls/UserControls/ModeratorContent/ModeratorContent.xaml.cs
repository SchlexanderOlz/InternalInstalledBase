namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;
using System.Windows;
using WpfApplication.Pages;

public partial class ModeratorContent : UserContent {

  public ModeratorContent(User user) : base(user) {

  }

  protected override void loadCustomerPage(object sender, RoutedEventArgs e) {
    var page = new ModeratorCustomerPage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }
}
