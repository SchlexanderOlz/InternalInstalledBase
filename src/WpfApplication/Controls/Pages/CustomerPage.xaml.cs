namespace WpfApplication.Pages;

using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using DapperExtension.DBContext.Models.Users;
using DataAccess;
using DataAccess.Commands;
using DapperExtension.DBContext.Models;


public partial class CustomerPage : UserControl {

  public NavBar ActionBar { get; set; }
  public CustomerExcelLikeGrid DataGrid { get; }
  protected readonly CustomerPageData dataContext;
  
  public CustomerPage(User user) : base() {
    this.InitializeComponent();
    this.dataContext = new();
    this.DataContext = this.dataContext;

    this.ActionBar = new();
    this.DataGrid = new(this.dataContext.Customers);
    this.DataGrid.MakeReadOnly();
    this.appendToGrid(this.DataGrid);

    this.dataContext.SearchCustomer.Execute(new CustomerData {});
    this.ActionBar.DataContext = this;

    var searchButton = new Button { Content = "Search", Command = this.dataContext.SearchCustomer};
    var backButton = new Button { Content = "Back" };
    var saveButton = new Button { Content = "Save", Command = this.dataContext.Edit};

    searchButton.SetResourceReference(Button.CommandParameterProperty, "CustomerData");

    this.ActionBar.Controls.Add(backButton);
    this.ActionBar.Controls.Add(searchButton);
    this.ActionBar.Controls.Add(saveButton);

    // TODO: Load enum members dynamically through iteration -> Maybe create another table
  }

  protected void appendToGrid(Control element) {
    this.contentGrid.Children.Add(element);
  }

  public void EditCell(object sender, EventArgs args) {
    this.dataContext.Edit.Execute(null);
  }
}
