namespace WpfApplication.UserControls;

using System.Windows.Controls;
using DapperExtension.DBContext.Models.Users;


public partial class UserContent : UserControl {
  public UserNavBar NavBar { get; set; }
  private User user;

  public UserContent(User user) {
    this.user = user;
    var customerButton = new Button { Content = "Customers" };
    var hardwareButton = new Button { Content = "Hardware" };
    this.NavBar = new();
    this.NavBar.Controls.Add(customerButton);
    this.NavBar.Controls.Add(hardwareButton);
    this.InitializeComponent();
  }
}
