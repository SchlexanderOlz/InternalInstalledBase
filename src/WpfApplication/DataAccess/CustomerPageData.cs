namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class CustomerPageData : PageData<Customer> 
{
  public CustomerPageData() : base(new SaveCustomer(), new AddCustomer(),
      new SearchCustomer())
  {

  }
  
}
