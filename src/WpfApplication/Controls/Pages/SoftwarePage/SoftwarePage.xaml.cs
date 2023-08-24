namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DataAccess.Commands;
using System.Windows.Controls;
using DataAccess;

public partial class SoftwarePage : ContentPage<Software>
{
  public SoftwarePage() : base(new SoftwarePageData())
  {
    this.InitializeComponent();

    this.DataGrid = new SoftwareExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    Grid.SetRow(this.DataGrid, 0);
    Grid.SetColumn(this.DataGrid, 3);
    Grid.SetRowSpan(this.DataGrid, 5);
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(new SoftwareData { });
  }
}
