/**
 * @file
 * @brief This file contains the definition of the AdminHardwarePage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class AdminHardwarePage : ModeratorHardwarePage
{
  public AdminHardwarePage() : base()
  {
    PageBuilder.UpgradeToAdmin(this);
  }
}

