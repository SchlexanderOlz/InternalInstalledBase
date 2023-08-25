namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class PropertyExcelGrid : ExcelLikeDataGrid<Property>
{
  public PropertyExcelGrid(ObservableCollection<Property> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Name",
      Binding = new Binding("Name")
    });

    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Effect",
      Binding = new Binding("Effect")
    });
  }

  static PropertyExcelGrid() { }
}
