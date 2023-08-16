namespace WpfApplication.Pages;

using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using DapperExtension.DBContext.Models.Users;
using DataAccess;
using DapperExtension.DBContext.Models;


public partial class CustomerPage : UserControl {

  public LowerActionBar ActionBar { get; set; }
  public Button SearchButton { get; set; }
  public Button BackButton { get; set; }
  protected readonly CustomerPageData dataContext;
  
  public CustomerPage(User user) : base() {
    this.ActionBar = new();
    this.ActionBar.DataContext = this;
    this.dataContext = new();
    this.DataContext = this.dataContext;

    this.SearchButton = new Button { Content = "Search", Command = this.dataContext.SearchCustomer};
    this.BackButton = new Button { Content = "Back" };

    this.SearchButton.SetResourceReference(Button.CommandParameterProperty, "CustomerData");

    this.ActionBar.ActionControls.Add(this.BackButton);
    this.ActionBar.ActionControls.Add(this.SearchButton);

    // TODO: Load enum members dynamically through iteration -> Maybe create another table
  }

  public void EditCell(object sender, DataGridCellEditEndingEventArgs args) {
    this.dataContext.Edit.Execute(null);
  }
}
