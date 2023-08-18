namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using DataAccess;
using DataAccess.Commands;
using DapperExtension.DBContext.Models;


public partial class CustomerPage : ContentPage<Customer> {

  public CustomerPage(User user) : base(new CustomerPageData()){
    this.InitializeComponent();

    this.DataGrid = new CustomerExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(new CustomerData {});
    // TODO: Load enum members dynamically through iteration -> Maybe create another table
  }

}
