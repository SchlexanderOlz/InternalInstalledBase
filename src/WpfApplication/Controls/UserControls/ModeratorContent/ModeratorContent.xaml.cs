/**
 * @file
 * @brief This file contains the definition of the ModeratorContent class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows;
using WpfApplication.Pages;

public partial class ModeratorContent : UserContent
{

  public ModeratorContent(Session session) : base(session) { }

#region PageLoaders
  protected override void loadPropertyPage(object sender, RoutedEventArgs e)
  {
    ModeratorPropertyPage page = new ModeratorPropertyPage();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadCustomerPage(object sender, RoutedEventArgs e)
  {
    ModeratorCustomerPage page = new ModeratorCustomerPage();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadProductPage(object sender, RoutedEventArgs e)
  {
    ModeratorProductPage page = new ModeratorProductPage();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadHardwarePage(object sender, RoutedEventArgs e)
  {
    ModeratorHardwarePage page = new ModeratorHardwarePage();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadSoftwarePage(object sender, RoutedEventArgs e)
  {
    ModeratorSoftwarePage page = new ModeratorSoftwarePage();
    this.addPage(page);
    page.InitializeComponent();
  }
#endregion
}
