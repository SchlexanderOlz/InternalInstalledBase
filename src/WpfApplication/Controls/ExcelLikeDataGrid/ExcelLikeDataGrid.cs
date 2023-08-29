/**
 * @file
 * @brief This file contains the definition of the ExcelLikeDataGrid abstact class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DapperExtension;
using System.Linq;
using System;
using System.Collections.Generic;


/**
 * @brief ExcelLikeDataGrid is a Control which contains a datagrid which binds to
 * all changes made in the supplied dataSource in the constructor. It is
 * automatically placed in the top-right corner
 */
public abstract class ExcelLikeDataGrid<T> : UserControl
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
    Grid.SetRowSpan(this, 10);
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

  /**
   * @brief Handles the keyDown event on the grid. Deletes the selected entrys
   * if not readonly
   */
  private void keyDown(object sender, KeyEventArgs e)
  {
    if (this.dataGrid.IsReadOnly)
    {
      return;
    }

    if (e.Key == Key.Delete)
    {
      this.OnDeleteEntry(this.GetSelectedItems());
      return;
    }
  }

  public void MakeReadOnly()
  {
    this.dataGrid.IsReadOnly = true;
  }

  public void MakeWritable()
  {
    this.dataGrid.IsReadOnly = false;
  }

  /**
   * @brief Returns all currently selected elements casted to type T
   */
  public ICollection<T> GetSelectedItems()
  {
    return this.dataGrid.SelectedItems.Cast<T>().ToList();
  }

  static ExcelLikeDataGrid() { }
}
