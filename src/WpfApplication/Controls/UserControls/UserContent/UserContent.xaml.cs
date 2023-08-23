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
    Button customerButton = new Button { Content = "Customers" };
    Button productButton = new Button { Content = "Products" };
    Button hardwareButton = new Button { Content = "Hardware" };
    Button softwareButton = new Button { Content = "Software" };
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

  protected void appendToGrid(UserControl element) {
    Grid.SetRow(element, 6);
    Grid.SetColumn(element, 1);
    this.userContent.Content = element;
  }

  protected virtual void loadCustomerPage(object sender, RoutedEventArgs e) {
    CustomerPage page = new CustomerPage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }

  protected virtual void loadProductPage(object sender, RoutedEventArgs e) {
    ProductPage page = new ProductPage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }

  protected virtual void loadHardwarePage(object sender, RoutedEventArgs e) {
    HardwarePage page = new HardwarePage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }

  protected virtual void loadSoftwarePage(object sender, RoutedEventArgs e) {
    SoftwarePage page = new SoftwarePage(this.user);
    appendToGrid(page);
    page.InitializeComponent();
  }
}
