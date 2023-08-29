/**
 * @file
 * @brief This file contains the definition of the ModeratorCustomerPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class ModeratorCustomerPage : CustomerPage
{

  public ModeratorCustomerPage() : base()
  {
    PageBuilder.UpgradeToModerator(this);
  }
}

