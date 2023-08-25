namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;

public class CustomerData : DescriptableSearchData
{
  public HelpDeskStatus Status { get; set; }

  public override void Clear()
  {
    base.Clear();
    this.Status = HelpDeskStatus.Transmitted;
  }
}
