namespace WpfApplication.Pages;

using System.Windows.Controls;
using System.Windows.Data;
using DapperExtension.DBContext.Models.Users;
using DataAccess;

public partial class CustomerPage : UserControl {

  public LowerActionBar ActionBar { get; set; }
  public Button SearchButton { get; set; }
  public Button BackButton { get; set; }
  
  public CustomerPage(User user) : base() {
    this.ActionBar = new();
    this.ActionBar.DataContext = this;
    CustomerPageData data = new();
    this.DataContext = data;

    this.SearchButton = new Button { Content = "Search", Command = data.SearchCustomer};
    this.BackButton = new Button { Content = "Back" };

    this.SearchButton.SetResourceReference(Button.CommandParameterProperty, "CustomerSearchData");

    this.ActionBar.ActionControls.Add(this.BackButton);
    this.ActionBar.ActionControls.Add(this.SearchButton);

    // TODO: Load enum members dynamically through iteration -> Maybe create another table
  }

}
