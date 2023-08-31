/**
 * @file
 * @brief This file contains the definition of the AdminProductPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;


public partial class AdminProductPage : ProductPage
{

  public AdminProductPage() : base()
  {
    this.UpgradeToAdmin();
  }
}

