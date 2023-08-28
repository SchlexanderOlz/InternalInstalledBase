namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class OptionExcelGrid : DescriptableExcelLikeGrid<Option>
{
  public OptionExcelGrid(ObservableCollection<Option> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Name",
      Binding = new Binding("OptionName")
    });
  }

  static OptionExcelGrid() { }
}
