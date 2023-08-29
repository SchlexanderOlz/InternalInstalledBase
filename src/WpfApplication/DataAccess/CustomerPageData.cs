/**
* @file
* @brief This file contains the definition of the CustomerPageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class CustomerPageData : PageData<Customer>
{
  public CustomerPageData() : base(new Save(), new AddCustomer(),
      new SearchCustomer(), new DeleteCustomer())
  {

  }

}
