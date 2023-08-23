namespace WpfApplication;

using System.Windows;
using DataAccess;
using System.Windows.Controls;


public abstract partial class DataGridWindow<T> : Window
{
  protected PageData<T> dataContext;

  public DataGridWindow(ExcelLikeDataGrid<T> grid, PageData<T> pageData)
  {
    this.dataContext = pageData;
    NavBar navBar = new();

    // Load the other page here instead
    Button addButton = new Button { Content = "Add" };
    addButton.Click += loadAddSearchPage;
    navBar.Controls.Add(addButton);

    grid.MakeReadOnly();

    DockPanel dockPanel = new();
    DockPanel.SetDock(navBar, Dock.Top);
    dockPanel.Children.Add(navBar);
    dockPanel.Children.Add(grid);

    this.Content = dockPanel;
  }

  protected abstract void loadAddSearchPage(object sender, RoutedEventArgs e); 
}
