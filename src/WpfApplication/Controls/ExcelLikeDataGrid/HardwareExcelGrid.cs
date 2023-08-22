namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using WpfApplication.ValueConverters;


public class HardwareExcelLikeGrid : DescriptableExcelLikeGrid<Hardware> 
{
  public HardwareExcelLikeGrid(ObservableCollection<Hardware> itemSource) : base(itemSource) {
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "IP Address",
            Binding = new Binding("Ip") { Converter = new IpConverter() } });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Material Number",
            Binding = new Binding("MaterialNumber")});
  }

  static HardwareExcelLikeGrid() {}
}
