namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using DataAccess.Commands;
using System.Windows.Controls;
using DataAccess;

public partial class UserPage : ContentPage<User> {
  public UserPage(User user) : base(new UserPageData()) {
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

    this.dataContext.Search.Execute(new UserData{});
  }
}
