/**
 * @file
 * @brief This file contains the definition of the ModeratorSoftwarePage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class ModeratorSoftwarePage : SoftwarePage
{

  public ModeratorSoftwarePage() : base()
  {
    this.UpgradeToModerator();
  }
}

