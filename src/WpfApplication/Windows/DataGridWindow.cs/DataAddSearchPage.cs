namespace WpfApplication;

using System.Windows;
using DataAccess;
using System.Windows.Controls;


public abstract partial class DataAddSearchPage<T> : Window {
  
  protected PageData<T> dataContext;
  protected ExcelLikeDataGrid<T> dataGrid;
  protected TextBox searchBox;

  public DataAddSearchPage(ExcelLikeDataGrid<T> dataGrid, PageData<T> dataContext) {
    this.dataContext = dataContext;
    this.dataGrid = dataGrid;

    TextBox searchBox = new TextBox();
    this.searchBox = searchBox;
    this.searchBox.Margin = new Thickness(5);
    this.searchBox.TextChanged += updateGrid;

    Button chooseButton = new Button{ Content = "Add" };
    NavBar navBar = new();
    navBar.Controls.Add(chooseButton);

    chooseButton.Click += appendData;

    DockPanel dockPanel = new();
    DockPanel.SetDock(this.searchBox, Dock.Top);
    dockPanel.Children.Add(this.searchBox);
    DockPanel.SetDock(navBar, Dock.Top);
    dockPanel.Children.Add(navBar);
    dockPanel.Children.Add(dataGrid);

    this.Content = dockPanel;
  }

  protected abstract void updateGrid(object sender, RoutedEventArgs e); 
  protected abstract void appendData(object sender, RoutedEventArgs e);
}
