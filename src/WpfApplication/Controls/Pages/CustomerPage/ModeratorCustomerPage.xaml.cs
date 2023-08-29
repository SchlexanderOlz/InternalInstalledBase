/**
 * @file
 * @brief This file contains the definition of the ModeratorCustomerPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using System.Windows.Controls;

public partial class ModeratorCustomerPage : CustomerPage
{

  public ModeratorCustomerPage() : base()
  {
    Button addButton = new Button { Content = "Add", Command = this.dataContext.Add };

    this.ActionBar.Controls.Add(addButton);
    this.DataGrid.MakeWritable();
    this.DataGrid.DeleteEntry += deleteEntry;
    addButton.SetResourceReference(Button.CommandParameterProperty, "Data");
  }
}

