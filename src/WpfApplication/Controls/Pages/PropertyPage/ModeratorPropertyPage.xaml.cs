/**
 * @file
 * @brief This file contains the definition of the ModeratorPropertyPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class ModeratorPropertyPage : PropertyPage
{

  public ModeratorPropertyPage() : base()
  {
    this.UpgradeToModerator();
  }
}

