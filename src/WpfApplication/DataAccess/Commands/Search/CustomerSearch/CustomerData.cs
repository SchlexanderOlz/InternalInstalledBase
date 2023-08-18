namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;

public class CustomerData : DescriptableSearchData {
  public HelpDeskStatus Status { get; set; } 
}
