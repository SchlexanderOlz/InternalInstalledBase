/**
 * @file
 * @brief This file contains the definition of the ModeratorHardwarePage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using System.Windows.Controls;

public partial class ModeratorHardwarePage : HardwarePage
{

  public ModeratorHardwarePage() : base()
  {
    Button addButton = new Button { Content = "Add", Command = this.dataContext.Add };

    this.ActionBar.Controls.Add(addButton);
    this.DataGrid.DeleteEntry += deleteEntry;
    this.DataGrid.MakeWritable();
    addButton.SetResourceReference(Button.CommandParameterProperty, "Data");
  }
}

