namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DapperExtension.DBContext.Models.Users;
using System;
using DataAccess;
using DataAccess.Commands;
using System.Windows.Controls;
using System.Windows;

public partial class ProductPage : ContentPage<Product> {
  public ProductPage(User user) : base(new ProductPageData()) {
    this.InitializeComponent();

    this.DataGrid = new ProductExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    Grid.SetRow(this.DataGrid, 0);
    Grid.SetColumn(this.DataGrid, 3);
    Grid.SetRowSpan(this.DataGrid, 15);
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(new ProductData {});
  }

  protected void loadHardwareLinkPage(object sender, RoutedEventArgs e)
  {
    ProductData data = (ProductData)((FrameworkElement)sender).FindResource("Data");
    HardwareAddSearch window = new(data); 
    window.Show();

  }

  protected void loadSoftwareLinkPage(object sender, RoutedEventArgs e)
  {
    ProductData data = (ProductData)((FrameworkElement)sender).FindResource("Data");
    SoftwareAddSearch window = new(data); 
    window.Show();

    MessageBox.Show(data.Hardware.Name);
  }
}
