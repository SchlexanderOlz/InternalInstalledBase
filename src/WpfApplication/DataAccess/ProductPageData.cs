namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class ProductPageData : PageData<Product>
{
  public ProductPageData() : base(new Save(), new AddProduct(),
      new SearchProduct(), new DeleteProduct())
  {

  }

}
