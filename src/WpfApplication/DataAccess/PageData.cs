namespace DataAccess;

using Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

public abstract class PageData<T> {
  public ICommand Save { get; set; }
  public ICommand Add { get; set; }
  public ICommand Search { get; set; }
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
  
  protected void displayError(object? sender, ErrorEventArgs args) {
    MessageBox.Show(args.Message);
  }

  private void displaySearch(object? sender, SearchResults<T> args) {
    this.GridData.Clear();
    foreach(var data in args.Data) {
      this.GridData.Add(data);
    }
  }
}
