namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models.Users;


public class UserExcelLikeGrid : ExcelLikeDataGrid<User>
{
  public UserExcelLikeGrid(ObservableCollection<User> itemSource) : base(itemSource) {
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Username",
            Binding = new Binding("UserName") });

        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "UserType",
            Binding = new Binding("UserType")});
  }

  static UserExcelLikeGrid() {}
}
