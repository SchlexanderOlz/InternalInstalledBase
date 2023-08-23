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
    this.dataGrid.SetItemSource(this.dataContext.GridData);
  }

  protected override void updateGrid(object sender, RoutedEventArgs e) {
    TextBox searchBox = this.searchBox;
    string searchText = searchBox.Text;

    this.dataContext.Search.Execute(new SubjectAreaData{ Name = searchText });
  }

  protected override void appendData(object sender, RoutedEventArgs e)
  {
    ICollection<SubjectArea> areas = this.dataGrid.GetSelectedItems();
    if (areas.Count == 0) {
      this.dataContext.Add.Execute(new SubjectAreaData{ Name = this.searchBox.Text,
          Customers = new Customer[] {this.customer}} );
    }
    this.customer.SubjectAreas = this.customer.SubjectAreas.Concat(areas).ToList();
    this.dataContext.Save.Execute(null);
  }
}
