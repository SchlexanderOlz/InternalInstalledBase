/**
 * @file
 * @brief This file contains the definition of the HardwareData class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System.Collections.Generic;

public class HardwareData : DescriptableSearchData
{
  public uint? Ip { get; set; }
  public uint? MaterialNumber { get; set; }
  public ICollection<ProductData>? Products { get; set; }

  public override void Clear()
  {
    base.Clear();
    this.Ip = null;
    this.MaterialNumber = null;
    this.Products = null;
  }
}
