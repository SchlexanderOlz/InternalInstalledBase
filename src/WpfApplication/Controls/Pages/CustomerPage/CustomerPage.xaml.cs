namespace WpfApplication.Pages;

using DataAccess;
using DataAccess.Commands;
using DapperExtension.DBContext.Models;


public partial class CustomerPage : ContentPage<Customer>
{

  public CustomerPage() : base(new CustomerPageData())
  {
    this.InitializeComponent();

    this.DataGrid = new CustomerExcelLikeGrid(this.dataContext.GridData);
    this.DataGrid.MakeReadOnly();
    this.contentGrid.Children.Add(this.DataGrid);

    this.dataContext.Search.Execute(new CustomerData { });
  }

}
