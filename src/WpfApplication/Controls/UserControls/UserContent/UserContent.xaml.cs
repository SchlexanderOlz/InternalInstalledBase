namespace WpfApplication.UserControls;

using System.Windows.Controls;
using System.Windows;
using System;
using DapperExtension.DBContext.Models.Users;
using WpfApplication.Pages;


public partial class UserContent : UserControl
{
  public NavBar NavBar { get; set; }
  public event EventHandler<Session> Back;
  protected Session session;
  protected object? lastPage;

  public UserContent(Session session) : base()
  {
    this.session = session;
    Button logoutButton = new Button { Content = "Logout" };
    Button customerButton = new Button { Content = "Customers" };
    Button productButton = new Button { Content = "Products" };
    Button hardwareButton = new Button { Content = "Hardware" };
    Button softwareButton = new Button { Content = "Software" };
    Button propertyButton = new Button { Content = "Properties" };
    this.NavBar = new();
    this.NavBar.Controls.Add(logoutButton);
    this.NavBar.Controls.Add(customerButton);
    this.NavBar.Controls.Add(productButton);
    this.NavBar.Controls.Add(hardwareButton);
    this.NavBar.Controls.Add(softwareButton);
    this.NavBar.Controls.Add(propertyButton);

    logoutButton.Click += logout;
    customerButton.Click += loadCustomerPage;
    productButton.Click += loadProductPage;
    hardwareButton.Click += loadHardwarePage;
    softwareButton.Click += loadSoftwarePage;
    propertyButton.Click += loadPropertyPage;
  }

  protected void addPage<T>(ContentPage<T> element)
  {
    Grid.SetRow(element, 6);
    Grid.SetColumn(element, 1);
    this.lastPage = this.userContent.Content;
    this.userContent.Content = element;
    element.Back += reset;
  }

  protected void reset(object? sender, EventArgs? e)
  {
    this.userContent.Content = this.lastPage;
    this.lastPage = null;
  }

  protected void logout(object? sender, EventArgs e)
  {
    OnBack(this.session);
  }

  protected virtual void OnBack(Session session)
  {
    this.Back?.Invoke(this, session);
  }

  protected virtual void loadPropertyPage(object sender, RoutedEventArgs e)
  {
    PropertyPage page = new();
    addPage(page);
    page.InitializeComponent();
  }

  protected virtual void loadCustomerPage(object sender, RoutedEventArgs e)
  {
    CustomerPage page = new CustomerPage();
    addPage(page);
    page.InitializeComponent();
  }

  protected virtual void loadProductPage(object sender, RoutedEventArgs e)
  {
    ProductPage page = new ProductPage();
    addPage(page);
    page.InitializeComponent();
  }

  protected virtual void loadHardwarePage(object sender, RoutedEventArgs e)
  {
    HardwarePage page = new HardwarePage();
    addPage(page);
    page.InitializeComponent();
  }

  protected virtual void loadSoftwarePage(object sender, RoutedEventArgs e)
  {
    SoftwarePage page = new SoftwarePage();
    addPage(page);
    page.InitializeComponent();
  }
}
