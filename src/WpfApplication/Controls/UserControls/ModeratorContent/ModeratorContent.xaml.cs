namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
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

  protected override void loadProductPage(object sender, RoutedEventArgs e)
  {
    var page = new ModeratorProductPage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }

  protected override void loadHardwarePage(object sender, RoutedEventArgs e)
  {
    var page = new ModeratorHardwarePage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }
}
