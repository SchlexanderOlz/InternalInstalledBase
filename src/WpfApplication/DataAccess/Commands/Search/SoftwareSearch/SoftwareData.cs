/**
* @file
* @brief This file contains the definition of the SoftwareData class
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;

using System.Collections.Generic;

public class SoftwareData : DescriptableSearchData
{
  public uint? Version { get; set; }
  public ICollection<ProductData>? Products { get; set; }

    public override void Clear()
    {
        base.Clear();
        this.Version = null;
        this.Products = null;
    }
}
