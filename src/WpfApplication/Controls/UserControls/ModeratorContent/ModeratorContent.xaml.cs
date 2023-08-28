namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows;
using WpfApplication.Pages;

public partial class ModeratorContent : UserContent
{

  public ModeratorContent(Session session) : base(session) { }

  protected override void loadPropertyPage(object sender, RoutedEventArgs e)
  {
    ModeratorPropertyPage page = new ModeratorPropertyPage();
    addPage(page);
    page.InitializeComponent();
  }

  protected override void loadCustomerPage(object sender, RoutedEventArgs e)
  {
    ModeratorCustomerPage page = new ModeratorCustomerPage();
    addPage(page);
    page.InitializeComponent();
  }

  protected override void loadProductPage(object sender, RoutedEventArgs e)
  {
    ModeratorProductPage page = new ModeratorProductPage();
    addPage(page);
    page.InitializeComponent();
  }

  protected override void loadHardwarePage(object sender, RoutedEventArgs e)
  {
    ModeratorHardwarePage page = new ModeratorHardwarePage();
    addPage(page);
    page.InitializeComponent();
  }

  protected override void loadSoftwarePage(object sender, RoutedEventArgs e)
  {
    ModeratorSoftwarePage page = new ModeratorSoftwarePage();
    addPage(page);
    page.InitializeComponent();
  }
}
