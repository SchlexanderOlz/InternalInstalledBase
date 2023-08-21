namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;


public class DescriptableExcelLikeGrid<T> : ExcelLikeDataGrid<T>
{
  public DescriptableExcelLikeGrid(ObservableCollection<T> itemSource) : base(itemSource) {
        this.dataGrid.ItemsSource = itemSource;
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Description", Binding = new Binding("Description") });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Shortcut", Binding = new Binding("Shortcut") });
  }

  static DescriptableExcelLikeGrid() {}
}
