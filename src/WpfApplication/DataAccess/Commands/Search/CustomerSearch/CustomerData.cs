/**
 * @file
 * @brief This file contains the definition of the CustomerData class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
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
