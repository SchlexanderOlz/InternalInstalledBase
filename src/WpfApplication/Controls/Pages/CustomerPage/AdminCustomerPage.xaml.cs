/**
 * @file
 * @brief This file contains the definition of the AdminCustomerPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class AdminCustomerPage : ModeratorCustomerPage
{
  public AdminCustomerPage() : base()
  {
    PageBuilder.UpgradeToAdmin(this);
  }
}

