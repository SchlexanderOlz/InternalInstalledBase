namespace WpfApplication;

using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class HardwareExcelLikeGrid : DescriptableExcelLikeGrid<Hardware> 
{
  public HardwareExcelLikeGrid(ObservableCollection<Hardware> itemSource) : base(itemSource) {
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "IP Address",
            Binding = new Binding("Ip") });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Material Number",
            Binding = new Binding("MaterialNumber")});
  }

  static HardwareExcelLikeGrid() {}
}
