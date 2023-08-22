namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows;
using WpfApplication.Pages;

public partial class ModeratorContent : UserContent {

  public ModeratorContent(User user) : base(user) {}

  protected override void loadCustomerPage(object sender, RoutedEventArgs e) {
    ModeratorCustomerPage page = new ModeratorCustomerPage(this.user);
    appendToGrid(page);
  }

  protected override void loadProductPage(object sender, RoutedEventArgs e)
  {
    ModeratorProductPage page = new ModeratorProductPage(this.user);
    appendToGrid(page);
  }

  protected override void loadHardwarePage(object sender, RoutedEventArgs e)
  {
    ModeratorHardwarePage page = new ModeratorHardwarePage(this.user);
    appendToGrid(page);
  }

  protected override void loadSoftwarePage(object sender, RoutedEventArgs e)
  {
    ModeratorSoftwarePage page = new ModeratorSoftwarePage(this.user);
    appendToGrid(page);
  }
}
