/**
 * @file
 * @brief This file contains the definition of the AdminContent class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;
using System.Windows;
using WpfApplication.Pages;


public partial class AdminContent : ModeratorContent
{
  public AdminContent(Session session) : base(session)
  {
    Button userButton = new Button { Content = "Users" };

    userButton.Click += loadUserPage;
    this.NavBar.Controls.Add(userButton);
  }

#region PageLoaders
  protected void loadUserPage(object sender, RoutedEventArgs args)
  {
    UserPage page = new UserPage();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadPropertyPage(object sender, RoutedEventArgs e)
  {
    AdminPropertyPage page = new();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadCustomerPage(object sender, RoutedEventArgs e)
  {
    AdminCustomerPage page = new();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadProductPage(object sender, RoutedEventArgs e)
  {
    AdminProductPage page = new();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadHardwarePage(object sender, RoutedEventArgs e)
  {
    AdminHardwarePage page = new();
    this.addPage(page);
    page.InitializeComponent();
  }

  protected override void loadSoftwarePage(object sender, RoutedEventArgs e)
  {
    AdminSoftwarePage page = new();
    this.addPage(page);
    page.InitializeComponent();
  }
#endregion
}
