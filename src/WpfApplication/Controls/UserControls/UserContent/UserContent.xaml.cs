namespace WpfApplication.UserControls;

using System.Windows.Controls;
using System.Windows;
using DapperExtension.DBContext.Models.Users;
using WpfApplication.Pages;


public partial class UserContent : UserControl {
  public NavBar NavBar { get; set; }
  protected User user;

  public UserContent(User user) : base() {
    this.user = user;
    var customerButton = new Button { Content = "Customers" };
    var productButton = new Button { Content = "Products" };
    var hardwareButton = new Button { Content = "Hardware" };
    var softwareButton = new Button { Content = "Software" };
    this.NavBar = new();
    this.NavBar.Controls.Add(customerButton);
    this.NavBar.Controls.Add(productButton);
    this.NavBar.Controls.Add(hardwareButton);
    this.NavBar.Controls.Add(softwareButton);

    customerButton.Click += loadCustomerPage;
    productButton.Click += loadProductPage;
    hardwareButton.Click += loadHardwarePage;
    softwareButton.Click += loadSoftwarePage;
  }

  protected void appendToGrid(Control element) {
    Grid? grid = this.Content as Grid;
    if (grid == null) {
      return;
    }
    Grid.SetRow(element, 1);
    grid.Children.Add(element);
  }

  protected virtual void loadCustomerPage(object sender, RoutedEventArgs e) {
    CustomerPage page = new CustomerPage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }

  protected virtual void loadProductPage(object sender, RoutedEventArgs e) {

  }

  protected virtual void loadHardwarePage(object sender, RoutedEventArgs e) {

  }

  protected virtual void loadSoftwarePage(object sender, RoutedEventArgs e) {

  }
}
