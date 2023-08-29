/**
* @file
* @brief This file contains the definition of the PageData abstract class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess;

using Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;


/**
 * @brief PageData is the base class for all modelview data. It contains all
 * database-interaction commands (Save, Add, Delete, etc.)
 */
public abstract class PageData<T>
{
  public ICommand Save { get; set; }
  public AddCommand Add { get; set; }
  public SearchCommand<T> Search { get; set; }
  public ICommand Delete { get; set; }
  public ObservableCollection<T> GridData { get; set; }

  public PageData(ICommand save, AddCommand add, SearchCommand<T> search,
      ICommand delete)
  {
    this.Save = save;
    this.Add = add;
    this.Search = search;
    this.Delete = delete;

    search.SearchResultIn += displaySearch;
    add.AddFailed += displayError;
    this.GridData = new();
  }

  public void SetDataGridItemSource(ObservableCollection<T> itemSource)
  {
    this.GridData = itemSource;
  }

  protected void displayError(object? sender, ErrorEventArgs args)
  {
    MessageBox.Show(args.Message);
  }

  private void displaySearch(object? sender, SearchResults<T> args)
  {
    this.GridData.Clear();
    foreach (var data in args.Data)
    {
      this.GridData.Add(data);
    }
  }
}
