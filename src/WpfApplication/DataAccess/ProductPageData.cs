namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class ProductPageData : PageData<Product> 
{
  public CustomerPageData() : base(new SaveProduct(), new AddProduct(),
      new SearchProduct())
  {

  }
  
}
