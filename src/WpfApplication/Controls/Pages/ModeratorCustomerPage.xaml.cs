namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;

public partial class ModeratorCustomerPage : CustomerPage {

  public ModeratorCustomerPage(User user) : base(user) {
    Button addButton = new Button { Content = "Add", Command = this.dataContext.AddCustomer };

    this.ActionBar.Controls.Add(addButton);
    this.DataGrid.MakeWritable();
    addButton.SetResourceReference(Button.CommandParameterProperty, "CustomerData");
  }
}

