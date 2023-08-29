/**
 * @file
 * @brief This file contains the definition of the ContentPage abstract class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using System.Windows.Controls;
using DataAccess;
using DataAccess.Commands;
using System;
using System.Collections.Generic;


/**
 * @brief ContentPage is the base class for all pages. It defines view components
 * which are used by all pages. It takes in a dataContext with the same type-param,
 * which contains all command which are always used (Add, Delete, etc.)
 */
public abstract class ContentPage<T> : UserControl
{
  public NavBar ActionBar { get; set; }
  public ExcelLikeDataGrid<T> DataGrid { get; protected set; }
  protected readonly PageData<T> dataContext;
  public event EventHandler Back;

  public ContentPage(PageData<T> dataContext) : base()
  {
    this.ActionBar = new();
    this.dataContext = dataContext;
    this.DataContext = this.dataContext;
    this.ActionBar.DataContext = this;

    // Buttons which are used to modify the data
    var searchButton = new Button { Content = "Search", Command = this.dataContext.Search };
    var backButton = new Button { Content = "Back" };
    var saveButton = new Button { Content = "Save", Command = this.dataContext.Save };

    searchButton.SetResourceReference(Button.CommandParameterProperty, "Data");
    backButton.Click += OnBack;

    this.dataContext.Add.AddSuccess += clearInputFields;
    this.dataContext.Add.AddSuccess += this.reloadGrid;

    this.ActionBar.Controls.Add(backButton);
    this.ActionBar.Controls.Add(searchButton);
    this.ActionBar.Controls.Add(saveButton);
  }

  protected virtual void OnBack(object sender, EventArgs e)
  {
    this.Back?.Invoke(this, EventArgs.Empty);
  }

  public void EditCell(object? sender, EventArgs args)
  {
    this.dataContext.Save.Execute(null);
  }

  protected void deleteEntry(object? sender, ICollection<T> deleted)
  {
    this.dataContext.Delete.Execute(deleted);
  }

  protected void reloadGrid(object? sender, EventArgs e) { this.dataContext.Search.Execute(null); }
  protected abstract void clearInputFields(object? sender, EventArgs e);
  protected abstract ISearchData getDataField();
}
