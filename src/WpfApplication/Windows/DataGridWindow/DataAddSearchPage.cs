/**
* @file
* @brief This file contains the definition of the DataAddSearchPage class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication;

using System.Windows;
using DataAccess;
using System.Windows.Controls;
using System.Collections.Generic;
using DataAccess.Commands;


/**
 * @brief The data add-search page contains an ExcelLikeGrid which contains data
 * of the specified type T
 */
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

    // Defintiion of the search TextBox
    TextBox searchBox = new TextBox();
    this.searchBox = searchBox;
    this.searchBox.Margin = new Thickness(5);
    this.searchBox.TextChanged += updateGrid;
    this.searchBox.TextChanged += collapseButton;

    // The chooseButton is hidden if the TextBox is empty
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

  /**
   * @brief The text of the TextBox is used to query for the input data and then
   * the grid is updated with the results
   */
  protected abstract void updateGrid(object sender, RoutedEventArgs e);

  /**
   * @brief Appends data to the element for which this associated page has been called
   */
  protected abstract void appendData(object sender, RoutedEventArgs e);

  /**
   * @brief Deletes data associated with the element in question
   */
  protected virtual void deleteEntry(object? sender, ICollection<T> deleted)
  {
    this.dataContext.Delete.Execute(deleted);
  }
}
