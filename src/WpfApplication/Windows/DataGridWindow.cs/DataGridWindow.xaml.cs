namespace WpfApplication;

using System.Windows;
using DataAccess;
using System.Collections.Generic;
using System.Windows.Controls;


public partial class DataGridWindow<T> : Window
{
  protected PageData<T> dataContext;

  public DataGridWindow(ExcelLikeDataGrid<T> grid, PageData<T> pageData)
  {
    this.dataContext = pageData;
    NavBar navBar = new();
    Button addButton = new Button { Content = "Add", Command = this.dataContext.Add };
    navBar.Controls.Add(addButton);

    grid.MakeReadOnly();

    DockPanel dockPanel = new();
    DockPanel.SetDock(navBar, Dock.Top);
    dockPanel.Children.Add(navBar);
    dockPanel.Children.Add(grid);

    this.Content = dockPanel;
  }
}
