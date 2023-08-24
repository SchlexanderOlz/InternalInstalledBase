namespace WpfApplication;

using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.Generic;
using System.Linq;

public partial class SoftwareAddSearch : DataAddSearchPage<Software>
{

  private ProductData product;

  public SoftwareAddSearch(ProductData product) : base(new SoftwareExcelLikeGrid(
        new ObservableCollection<Software>()), new SoftwarePageData())
  {
    this.product = product;
    this.dataContext.Search.Execute(new SoftwareData { });
  }

  protected override void updateGrid(object sender, RoutedEventArgs e)
  {
    TextBox searchBox = (TextBox)sender;
    string searchText = searchBox.Text;

    if (searchText.Length == 0)
    {
      this.dataContext.Search.Execute(new SoftwareData { });
      return;
    }

    this.dataContext.Search.Execute(new SoftwareData { Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    // Make sure only one element comes in
    ICollection<Software> software = this.dataGrid.GetSelectedItems();
    if (software.Count() == 0)
    {
      return;
    }
    if (software.Count() > 1)
    {
      MessageBox.Show("Can only select one Hardware");
      return;
    }
    this.product.Software = software.Last();
  }
}
