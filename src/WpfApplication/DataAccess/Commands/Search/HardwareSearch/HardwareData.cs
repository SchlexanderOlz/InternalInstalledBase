namespace DataAccess.Commands;


public class HardwareData : DescriptableSearchData {
  public uint? Ip { get; set; }
  public uint? MaterialNumber { get; set; }
}
