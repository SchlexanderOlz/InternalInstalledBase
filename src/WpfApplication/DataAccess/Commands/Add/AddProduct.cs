namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;


public class AddProduct : AddCommand
{
  public AddProduct() : base() { }

  public override void Execute(object? param)
  {
    ProductData? productData = param as ProductData;
    if (productData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(CustomerData)}"));
      return;
    }

    if (productData.Name == null || productData.Description == null ||
        productData.Shortcut == null || productData.Hardware == null || productData.Software == null)
    {
      string msg = "Missing fields";
      if (productData.Name == null)
      {
        msg += ", " + nameof(productData.Name);
      }
      if (productData.Description == null)
      {
        msg += ", " + nameof(productData.Description);
      }
      if (productData.Shortcut == null)
      {
        msg += ", " + nameof(productData.Shortcut);
      }
      OnAddFailed(new ErrorEventArgs(msg));
      return;
    }
    this.dbConnection.InsertProduct(new Product(productData.Name,
        productData.Description, productData.Shortcut, productData.Hardware, productData.Software));
    }
}
