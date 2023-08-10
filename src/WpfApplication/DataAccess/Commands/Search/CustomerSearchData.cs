namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;

public class CustomerSeachData : DescriptableSearchData {
  public HelpDeskStatus Status { get; set; } 
}
