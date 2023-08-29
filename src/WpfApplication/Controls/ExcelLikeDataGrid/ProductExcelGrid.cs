/**
 * @file
 * @brief This file contains the definition of the ProductExcelLikeGrid class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class ProductExcelLikeGrid : DescriptableExcelLikeGrid<Product>
{
  public ProductExcelLikeGrid(ObservableCollection<Product> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Hardware Name",
      Binding = new Binding("Hardware.Name")
    });

    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Software Name",
      Binding = new Binding("Software.Name")
    });
  }

  static ProductExcelLikeGrid() { }
}
