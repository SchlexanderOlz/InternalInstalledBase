namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;

public class CustomerSearchData : DescriptableSearchData {
  public HelpDeskStatus Status { get; set; } 
}
