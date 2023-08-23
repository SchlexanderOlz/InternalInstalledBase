namespace WpfApplication;

using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.Generic;
using System.Linq;

public partial class ProductAddSearchPage : DataAddSearchPage<Product> {

  private Customer customer;

  public ProductAddSearchPage(Customer customer) : base(new ProductExcelLikeGrid(
        new ObservableCollection<Product>()), new ProductPageData()) {
    this.customer = customer;
  }

  protected override void updateGrid(object sender, RoutedEventArgs e)
  {
    TextBox searchBox = (TextBox)sender;
    string searchText = searchBox.Text;

    this.dataContext.Search.Execute(new ProductData{ Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    ICollection<Product> products = this.dataGrid.GetSelectedItems();
    this.customer.Products = this.customer.Products.Concat(products).ToList();
    this.dataContext.Save.Execute(null);
  }
}
