namespace WpfApplication;

using System.Windows;
using DataAccess;
using System.Windows.Controls;
using System.Collections.Generic;
using DataAccess.Commands;


public abstract partial class DataAddSearchPage<T> : Window
{

  protected PageData<T> dataContext;
  protected ExcelLikeDataGrid<T> dataGrid;
  protected TextBox searchBox;
  protected Button chooseButton;

  public DataAddSearchPage(ExcelLikeDataGrid<T> dataGrid, PageData<T> dataContext)
  {
    this.dataContext = dataContext;
    this.dataGrid = dataGrid;

    TextBox searchBox = new TextBox();
    this.searchBox = searchBox;
    this.searchBox.Margin = new Thickness(5);
    this.searchBox.TextChanged += updateGrid;
    this.searchBox.TextChanged += collapseButton;

    Button chooseButton = new Button { Content = "Add" };
    NavBar navBar = new();
    navBar.Controls.Add(chooseButton);

    chooseButton.Click += appendData;
    chooseButton.Visibility = Visibility.Collapsed;
    this.chooseButton = chooseButton;

    DockPanel dockPanel = new();
    DockPanel.SetDock(this.searchBox, Dock.Top);
    dockPanel.Children.Add(this.searchBox);
    DockPanel.SetDock(navBar, Dock.Top);
    dockPanel.Children.Add(navBar);
    dockPanel.Children.Add(dataGrid);

    this.Content = dockPanel;
    this.dataGrid.SetItemSource(this.dataContext.GridData);
    this.dataGrid.DeleteEntry += deleteEntry;
    this.dataGrid.MakeReadOnly();

    this.dataContext.Search.SearchResultIn += reloadSearch;
  }

  protected virtual void collapseButton(object sender, RoutedEventArgs e)
  {
    if (string.IsNullOrEmpty(this.searchBox.Text))
    {
      this.chooseButton.Visibility = Visibility.Collapsed;
    }
    else
    {
      this.chooseButton.Visibility = Visibility.Visible;
    }
  }

  protected abstract void updateGrid(object sender, RoutedEventArgs e);
  protected abstract void appendData(object sender, RoutedEventArgs e);
  protected virtual void deleteEntry(object? sender, ICollection<T> deleted)
  {
    this.dataContext.Delete.Execute(deleted);
  }
  protected abstract void reloadSearch(object sender, SearchResults<T> e);
}
