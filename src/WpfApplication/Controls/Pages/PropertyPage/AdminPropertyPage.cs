/**
 * @file
 * @brief This file contains the definition of the AdminPropertyPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class AdminPropertyPage : PropertyPage
{

  public AdminPropertyPage() : base()
  {
    PageBuilder.UpgradeToAdmin(this);
  }
}

