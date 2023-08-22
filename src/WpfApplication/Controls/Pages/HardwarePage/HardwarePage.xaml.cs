namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DapperExtension.DBContext.Models.Users;
using DataAccess;
using DataAccess.Commands;
using System.Windows.Controls;

public partial class HardwarePage : ContentPage<Hardware> {
  public HardwarePage(User user) : base(new HardwarePageData()) {
    this.InitializeComponent();

    this.DataGrid = new HardwareExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    Grid.SetRow(this.DataGrid, 0);
    Grid.SetColumn(this.DataGrid, 3);
    Grid.SetRowSpan(this.DataGrid, 5);
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(new HardwareData{});
  }
}
