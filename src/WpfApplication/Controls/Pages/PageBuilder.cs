/**
 * @file
 * @brief This file contains the definition of the ContentPage abstract class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using System.Windows.Controls;


public static class PageBuilder
{

  public static void UpgradeToModerator<T>(ContentPage<T> entity)
  {
    entity.DataGrid.MakeWritable();
  }

  public static void UpgradeToAdmin<T>(ContentPage<T> entity)
  {
    entity.DataGrid.MakeDeleteable();

    Button addButton = new Button { Content = "Add", Command = entity.GetDataContext().Add };
    entity.ActionBar.Controls.Add(addButton);
    entity.DataGrid.DeleteEntry += entity.DeleteEntry;

    addButton.SetResourceReference(Button.CommandParameterProperty, "Data");

  }
}
