/**
 * @file
 * @brief This file contains the definition of the ProductData class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System.Collections.Generic;

public class ProductData : DescriptableSearchData
{
  public Software? Software { get; set; }
  public Hardware? Hardware { get; set; }
  public ICollection<Customer>? Customers { get; set; }

  public override void Clear()
  {
      base.Clear();
      this.Software = null;
      this.Hardware = null;
      this.Customers = null;
  }
}
