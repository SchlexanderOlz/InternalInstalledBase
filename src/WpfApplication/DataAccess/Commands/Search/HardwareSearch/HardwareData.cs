namespace DataAccess.Commands;

using System.Collections.Generic;

public class HardwareData : DescriptableSearchData
{
  public uint? Ip { get; set; }
  public uint? MaterialNumber { get; set; }
  public ICollection<ProductData>? Products { get; set; }
}
