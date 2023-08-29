/**
 * @file
 * @brief This file contains the definition of the SoftwareExcelLikeGrid class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class SoftwareExcelLikeGrid : DescriptableExcelLikeGrid<Software>
{
  public SoftwareExcelLikeGrid(ObservableCollection<Software> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Version Number",
      Binding = new Binding("Version")
    });
  }

  static SoftwareExcelLikeGrid() { }
}
