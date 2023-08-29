/**
 * @file
 * @brief This file contains the definition of the CustomerPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using DataAccess;
using System;
using System.Windows;
using DataAccess.Commands;
using DapperExtension.DBContext.Models;


public partial class CustomerPage : ContentPage<Customer>
{

  public CustomerPage() : base(new CustomerPageData())
  {
    this.InitializeComponent();

    this.DataGrid = new CustomerExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(null);
  }

  protected override void clearInputFields(object? sender, EventArgs e)
  {
    this.nameTextBox.Clear();
    this.descriptionTextBox.Clear();
    this.shortcutTextBox.Clear();
    this.getDataField().Clear();
  }

  protected override ISearchData getDataField()
  {
    return (CustomerData)((FrameworkElement)this.actionBar).FindResource("Data");
  }
}
