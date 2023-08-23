namespace WpfApplication;

using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DapperExtension;
using System.Linq;
using System;
using System.Collections.Generic;

public class ExcelLikeDataGrid<T> : UserControl
{
    protected DataGrid dataGrid;
    protected DBInteraction dbConnection;
    public event EventHandler<ICollection<T>>? DeleteEntry;

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

    protected void OnDeleteEntry(ICollection<T> deleted)
    {
      this.DeleteEntry?.Invoke(this, deleted);
    }

    public void SetItemSource(ObservableCollection<T> itemSource)
    {
      this.dataGrid.ItemsSource = itemSource;
    }

    private void keyDown(object sender, KeyEventArgs e) {
      if (this.dataGrid.IsReadOnly) {
        return;
      }

      if (e.Key == Key.Delete)
      {
        this.OnDeleteEntry(this.GetSelectedItems());
        return;
      }
    }

    public void MakeReadOnly() {
      this.dataGrid.IsReadOnly = true;
    }

    public void MakeWritable() {
      this.dataGrid.IsReadOnly = false;
    }

    public ICollection<T> GetSelectedItems() {
      return this.dataGrid.SelectedItems.Cast<T>().ToList();
    }

    static ExcelLikeDataGrid() {}
}
