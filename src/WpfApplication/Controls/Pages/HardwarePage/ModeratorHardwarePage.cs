/**
 * @file
 * @brief This file contains the definition of the ModeratorHardwarePage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class ModeratorHardwarePage : HardwarePage
{

  public ModeratorHardwarePage() : base()
  {
    PageBuilder.UpgradeToModerator(this);
  }
}

