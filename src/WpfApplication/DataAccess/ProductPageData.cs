/**
* @file
* @brief This file contains the definition of the ProductPageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
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
