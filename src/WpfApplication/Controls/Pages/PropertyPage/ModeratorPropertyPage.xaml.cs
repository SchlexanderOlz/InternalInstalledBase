namespace WpfApplication.Pages;

using System.Windows.Controls;

public partial class ModeratorPropertyPage : PropertyPage
{

  public ModeratorPropertyPage() : base()
  {
    Button addButton = new Button { Content = "Add", Command = this.dataContext.Add };

    this.ActionBar.Controls.Add(addButton);
    this.DataGrid.MakeWritable();
    this.DataGrid.DeleteEntry += deleteEntry;
    addButton.SetResourceReference(Button.CommandParameterProperty, "Data");
  }
}

