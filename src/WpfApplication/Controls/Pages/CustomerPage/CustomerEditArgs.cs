namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;

public class CustomerEditedArgs {
  public Customer Customer { get; }  
  public CustomerEditedArgs(Customer customer) {
    this.Customer = customer;
  }
}
