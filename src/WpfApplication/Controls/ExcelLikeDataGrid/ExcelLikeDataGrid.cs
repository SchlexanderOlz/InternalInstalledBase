namespace WpfApplication;

using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DapperExtension.DBContext.Models;
using DapperExtension;
using System.Linq;

public class ExcelLikeDataGrid<T> : UserControl
{
    protected DataGrid dataGrid;
    protected DBInteraction dbConnection;
    public ExcelLikeDataGrid(ObservableCollection<T> itemSource) : base()
    {
      this.dataGrid = new DataGrid
      {
        Name = "dataGrid",
        ItemsSource = itemSource,
        AutoGenerateColumns = false,
      };
      Grid.SetColumn(this, 2);
      Grid.SetRow(this, 0);
      Grid.SetRowSpan(this, 7);
      this.Content = this.dataGrid;
      this.dbConnection = DBInteraction.GetInstance();
      this.dataGrid.PreviewKeyDown += this.keyDown;
    }

    private void keyDown(object sender, KeyEventArgs e) {
      if (this.dataGrid.IsReadOnly) {
        return;
      }

      if (e.Key == Key.Delete)
      {
        this.dbConnection.DeleteCustomers(this.dataGrid.SelectedItems.Cast<Customer>().ToList());
        return;
      }

    }

    public void MakeReadOnly() {
      this.dataGrid.IsReadOnly = true;
    }

    public void MakeWritable() {
      this.dataGrid.IsReadOnly = false;
    }

    static ExcelLikeDataGrid() {}
}
