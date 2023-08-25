namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using System;
using System.Windows;
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

  protected override void clearInputFields(object? sender, EventArgs e)
  {
    this.nameTextBox.Clear();
    this.descriptionTextBox.Clear();
    this.shortcutTextBox.Clear();
    this.versionTextBox.Clear();
    this.getDataField().Clear();
  }

  protected override ISearchData getDataField()
  {
    return (SoftwareData)((FrameworkElement)this.actionBar).FindResource("Data");
  }
}
