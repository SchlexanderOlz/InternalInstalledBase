namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.ObjectModel;


public partial class ProductDataGridWindow : DataGridWindow<Product> {
  public ProductDataGridWindow(ObservableCollection<Product> itemSource)
    : base(new ProductExcelLikeGrid(itemSource), new ProductPageData())
  {
  }
}
