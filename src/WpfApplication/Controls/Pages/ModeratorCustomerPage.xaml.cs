namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;
using System.Windows;
using System;

public partial class ModeratorCustomerPage : CustomerPage {

  public ModeratorCustomerPage(User user) : base(user) {
    Button addButton = new Button { Content = "Add", Command = this.dataContext.AddCustomer};

    this.ActionBar.ActionControls.Add(addButton);
    addButton.SetResourceReference(Button.CommandParameterProperty, "CustomerData");
  }
}

