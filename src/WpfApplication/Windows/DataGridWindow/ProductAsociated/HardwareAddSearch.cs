/**
* @file
* @brief This file contains the definition of the HardwareAddSearch class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication;

using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.Generic;
using System.Linq;

public partial class HardwareAddSearch : DataAddSearchPage<Hardware>
{

  private ProductData product;

  public HardwareAddSearch(ProductData product) : base(new HardwareExcelLikeGrid(
        new ObservableCollection<Hardware>()), new HardwarePageData())
  {
    this.product = product;
    this.dataContext.Search.Execute(new HardwareData { });
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
    ICollection<Hardware> hardware = this.dataGrid.GetSelectedItems();
    if (hardware.Count() == 0)
    {
      return;
    }
    if (hardware.Count() > 1)
    {
      MessageBox.Show("Can only select one Hardware");
      return;
    }
    this.product.Hardware = hardware.Last();
  }

  protected override void reloadSearch(object sender, SearchResults<Hardware> e)
  {
    this.dataContext.Search.Execute(new HardwareData { Name = this.searchBox.Text });
  }
}
