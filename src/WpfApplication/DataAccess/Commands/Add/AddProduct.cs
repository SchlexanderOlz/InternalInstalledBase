/**
 * @file
 * @brief This file contains the definition of the AddProduct class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System;


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

    if (isNull(productData.Name) || isNull(productData.Description) ||
        isNull(productData.Shortcut) || productData.Hardware == null || productData.Software == null)
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

    try {
      this.dbConnection.InsertProduct(new Product(productData.Name,
          productData.Description, productData.Shortcut, productData.Hardware, productData.Software));
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }
}
