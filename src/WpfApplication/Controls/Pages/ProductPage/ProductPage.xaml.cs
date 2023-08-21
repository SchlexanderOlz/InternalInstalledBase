namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DapperExtension.DBContext.Models.Users;
using DataAccess;
using DataAccess.Commands;
using System.Windows.Controls;

public partial class ProductPage : ContentPage<Product> {
  public ProductPage(User user) : base(new ProductPageData()) {
    this.InitializeComponent();

    this.DataGrid = new ProductExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    Grid.SetRow(this.DataGrid, 0);
    Grid.SetColumn(this.DataGrid, 3);
    Grid.SetRowSpan(this.DataGrid, 5);
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(new ProductData {});
  }
}
