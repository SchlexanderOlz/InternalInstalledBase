namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using System;
using System.Windows;
using DataAccess.Commands;
using System.Windows.Controls;
using DataAccess;

public partial class UserPage : ContentPage<User>
{
  public UserPage() : base(new UserPageData())
  {
    this.InitializeComponent();

    this.DataGrid = new UserExcelLikeGrid(this.dataContext.GridData);
    Grid.SetRow(this.DataGrid, 0);
    Grid.SetColumn(this.DataGrid, 3);
    Grid.SetRowSpan(this.DataGrid, 5);
    this.contentGrid.Children.Add(this.DataGrid);

    Button addButton = new Button { Content = "Add", Command = this.dataContext.Add };

    this.ActionBar.Controls.Add(addButton);
    this.DataGrid.DeleteEntry += deleteEntry;
    addButton.SetResourceReference(Button.CommandParameterProperty, "Data");

    this.dataContext.Search.Execute(new UserData { });
  }

  protected override void clearInputFields(object? sender, EventArgs e)
  {
    this.userNameTextBox.Clear();
    this.password.Clear();
    this.getDataField().Clear();
  }

  protected override ISearchData getDataField()
  {
    return (SoftwareData)((FrameworkElement)this.actionBar).FindResource("Data");
  }
}
