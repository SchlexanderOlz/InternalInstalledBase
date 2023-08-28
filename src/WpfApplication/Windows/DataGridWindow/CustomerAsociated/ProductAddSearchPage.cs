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

public partial class ProductAddSearchPage : DataAddSearchPage<Product>
{

  private Customer customer;

  public ProductAddSearchPage(Customer customer) : base(new ProductExcelLikeGrid(
        new ObservableCollection<Product>()), new ProductPageData())
  {
    this.customer = customer;
    this.dataContext.Search.Execute(new ProductData { Customers = new Customer[] { customer } });
  }

  protected override void updateGrid(object sender, RoutedEventArgs e)
  {
    TextBox searchBox = (TextBox)sender;
    string searchText = searchBox.Text;

    if (searchText.Length == 0)
    {
      this.dataContext.Search.Execute(new ProductData { Customers = new Customer[] { this.customer } });
    }

    this.dataContext.Search.Execute(new ProductData { Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    ICollection<Product> products = this.dataGrid.GetSelectedItems();
    if (this.customer.Products == null)
    {
      this.customer.Products = products;
    }
    else
    {
      this.customer.Products = this.customer.Products.Concat(products).ToList();
    }

    this.dataContext.Save.Execute(null);

  }

  protected override void reloadSearch(object sender, SearchResults<Product> e)
  {
    this.dataContext.Search.Execute(new ProductData { Name = this.searchBox.Text });
  }
}
