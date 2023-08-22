using System.Windows;
using DataAccess;
using System.Collections.Generic;

namespace WpfApplication;

public partial class DataGridWindow<T> : Window
{
  public ExcelLikeDataGrid<T> DataGrid { get; set; }
  protected PageData<T> dataContext;

  public DataGridWindow(ExcelLikeDataGrid<T> grid, PageData<T> pageData)
  {
    this.dataContext = pageData;
    this.DataGrid = grid; 
    this.DataGrid.MakeReadOnly();
    this.Content = this.DataGrid;
  }
}
