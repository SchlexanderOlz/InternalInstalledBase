/**
 * @file
 * @brief This file contains the definition of the AdminSoftwarePage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class AdminSoftwarePage : SoftwarePage
{

  public AdminSoftwarePage() : base()
  {
    PageBuilder.UpgradeToAdmin(this);
  }
}

