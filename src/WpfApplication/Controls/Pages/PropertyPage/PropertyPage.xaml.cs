/**
 * @file
 * @brief This file contains the definition of the PropertyPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DataAccess;
using System;
using DataAccess.Commands;
using System.Windows.Controls;
using System.Windows;

public partial class PropertyPage : ContentPage<Property>
{
  public PropertyPage() : base(new PropertyPageData())
  {
    this.InitializeComponent();

    this.DataGrid = new PropertyExcelGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    Grid.SetRow(this.DataGrid, 0);
    Grid.SetColumn(this.DataGrid, 3);
    Grid.SetRowSpan(this.DataGrid, 15);
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(null);
  }

  protected override void clearInputFields(object? sender, EventArgs e)
  {
    this.nameTextBox.Clear();
    this.propertyTextBox.Clear();
    this.getDataField().Clear();
  }

  protected override ISearchData getDataField()
  {
    return (PropertyData)((FrameworkElement)this.actionBar).FindResource("Data");
  }
}
