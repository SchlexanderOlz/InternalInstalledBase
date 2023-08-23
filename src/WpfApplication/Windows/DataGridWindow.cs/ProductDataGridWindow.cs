namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DataAccess;
using System.Collections.ObjectModel;
using System.Windows;

public partial class ProductDataGridWindow : DataGridWindow<Product> {
  private Customer customer;

  public ProductDataGridWindow(Customer customer, ObservableCollection<Product> itemSource)
    : base(new ProductExcelLikeGrid(itemSource), new ProductPageData())
  {
    this.customer = customer;
  }

    protected override void loadAddSearchPage(object sender, RoutedEventArgs e)
    {
      ProductAddSearchPage page = new(this.customer);
      page.Show();
    }
}
