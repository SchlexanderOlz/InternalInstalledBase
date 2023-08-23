namespace WpfApplication;

using System.Windows;
using DataAccess;
using System.Windows.Controls;


public abstract partial class DataAddSearchPage<T> : Window {
  
  protected PageData<T> dataContext;
  protected ExcelLikeDataGrid<T> dataGrid;

  public DataAddSearchPage(ExcelLikeDataGrid<T> dataGrid, PageData<T> dataContext) {
    this.dataContext = dataContext;
    this.dataGrid = dataGrid;

    TextBox searchBox = new TextBox();
    searchBox.Margin = new Thickness(5);
    searchBox.TextChanged += updateGrid;

    Button chooseButton = new Button{ Name = "Add" };
    chooseButton.Click += appendData;

    DockPanel dockPanel = new();
    DockPanel.SetDock(searchBox, Dock.Top);
    dockPanel.Children.Add(searchBox);
    DockPanel.SetDock(chooseButton, Dock.Top);
    dockPanel.Children.Add(chooseButton);
    dockPanel.Children.Add(dataGrid);

    this.Content = dockPanel;
  }

  protected abstract void updateGrid(object sender, RoutedEventArgs e); 
  protected abstract void appendData(object sender, RoutedEventArgs e);
}
