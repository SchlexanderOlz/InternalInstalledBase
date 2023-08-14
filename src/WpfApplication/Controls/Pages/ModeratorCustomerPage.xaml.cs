namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;
using System.Windows;

public partial class ModeratorCustomerPage : CustomerPage {

  public ModeratorCustomerPage(User user) : base(user) {
    var addButton = new Button { Content = "Add", Command = this.dataContext.AddCustomer};
    this.ActionBar.ActionControls.Add(addButton);
    addButton.SetResourceReference(Button.CommandParameterProperty, "CustomerData");
  }
}

