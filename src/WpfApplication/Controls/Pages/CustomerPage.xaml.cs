namespace WpfApplication.Pages;

using System.Windows.Controls;
using DapperExtension.DBContext.Models.Users;

public partial class CustomerPage : Control {

  public LowerActionBar ActionBar { get; set; }
  
  public CustomerPage(User user) : base() {
    this.ActionBar = new();
    this.ActionBar.DataContext = this;

    // This is not being loaded correctly
    this.ActionBar.Controls.Add(new Button { Content = "Example" });
  }

  static CustomerPage() {

  }
}
