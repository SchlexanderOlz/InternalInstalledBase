namespace DataAccess.Commands;

using System.Collections.Generic;

public class SoftwareData : DescriptableSearchData {
  public uint? Version { get; set; } 
  public ICollection<ProductData>? Products { get; set; }
}
