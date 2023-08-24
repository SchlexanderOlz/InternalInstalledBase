namespace WpfApplication;

using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using DataAccess;
using DataAccess.Commands;
using System.Collections.Generic;
using System.Linq;

public partial class SubjectAreaAddSearch : DataAddSearchPage<SubjectArea> {

  private Customer customer;

  public SubjectAreaAddSearch(Customer customer) : base(new SubjectAreaExcelLikeGrid(
        new ObservableCollection<SubjectArea>()), new SubjectAreaPageData()) {
    this.customer = customer;
    this.dataContext.Search.Execute(new SubjectAreaData{ Customers = new Customer[] { customer }});
    this.dataGrid.MakeWritable();
  }

  protected override void updateGrid(object sender, RoutedEventArgs e) {
    TextBox searchBox = this.searchBox;
    string searchText = searchBox.Text;

    if (searchText.Length == 0)
    {
      this.dataContext.Search.Execute(new SubjectAreaData{ Customers = new Customer[] {this.customer}});
      return;
    }
    this.dataContext.Search.Execute(new SubjectAreaData{ Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    ICollection<SubjectArea> areas = this.dataGrid.GetSelectedItems();
    if (areas.Count == 0) {
      this.dataContext.Add.Execute(new SubjectAreaData{ Name = this.searchBox.Text,
          Customers = new Customer[] { this.customer }} );
    }

    if (this.customer.SubjectAreas == null)
    {
      this.customer.SubjectAreas = areas;
    } else {
      this.customer.SubjectAreas = this.customer.SubjectAreas.Concat(areas).ToList();
    }
    this.dataContext.Save.Execute(null);
  }
}
