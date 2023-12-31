/**
* @file
* @brief This file contains the definition of the PropertiesAddSearch class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication;

using System.Windows;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.Generic;
using System.Linq;

public partial class PropertiesAddSearch : DataAddSearchPage<Property>
{

  private ProductData product;

  public PropertiesAddSearch(ProductData product) : base(new PropertyExcelGrid(
        new ObservableCollection<Property>()), new PropertyPageData())
  {
    this.product = product;
    this.dataContext.Search.Execute(new HardwareData { });
    // TODO:
    // Implement PropertyAddSearch -> How to display Effect-value in grid and how to add
    throw new NotImplementedException();
  }

  protected override void updateGrid(object sender, RoutedEventArgs e)
  {
    TextBox searchBox = (TextBox)sender;
    string searchText = searchBox.Text;

    if (searchText.Length == 0)
    {
      this.dataContext.Search.Execute(new HardwareData { });
      return;
    }

    this.dataContext.Search.Execute(new HardwareData { Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    ICollection<Property> hardware = this.dataGrid.GetSelectedItems();
    if (hardware.Count() == 0)
    {
      return;
    }
    if (hardware.Count() > 1)
    {
      MessageBox.Show("Can only select one Hardware");
      return;
    }
  }
}
