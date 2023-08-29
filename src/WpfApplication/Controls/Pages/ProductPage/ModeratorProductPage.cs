/**
 * @file
 * @brief This file contains the definition of the ModeratorProductPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class ModeratorProductPage : ProductPage
{

  public ModeratorProductPage() : base()
  {
    PageBuilder.UpgradeToModerator(this);
  }
}

