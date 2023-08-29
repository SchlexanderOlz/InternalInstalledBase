/**
* @file
* @brief This file contains the definition of the OptionAddSearchPage class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication;

using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.Generic;
using System.Linq;


public partial class OptionAddSearchPage : DataAddSearchPage<Option>
{

  private Property property;

  public OptionAddSearchPage(Property property) : base(new OptionExcelGrid(
        new ObservableCollection<Option>()), new OptionPageData())
  {
    this.property = property;
    this.dataGrid.MakeWritable();
    this.dataContext.Search.Execute(new OptionData { Property = this.property });
  }

  protected override void updateGrid(object sender, RoutedEventArgs e)
  {
    TextBox searchBox = (TextBox)sender;
    string searchText = searchBox.Text;

    if (searchText.Length == 0)
    {
      this.dataContext.Search.Execute(new OptionData { Property = this.property });
      return;
    }

    this.dataContext.Search.Execute(new OptionData { Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    ICollection<Option> options = this.dataGrid.GetSelectedItems();
    if (options.Count() == 0)
    {
      string text = this.searchBox.Text;
      if (text.Length == 0)
      {
        return;
      }
      this.dataContext.Add.Execute(new OptionData { Name = text,
          Property = this.property });
      return;
    }

    this.property.Options.Concat(options);
  }
}
