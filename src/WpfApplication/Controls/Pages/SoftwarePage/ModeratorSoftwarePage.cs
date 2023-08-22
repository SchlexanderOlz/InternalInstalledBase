namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models.Users;
using System.Windows.Controls;

public partial class ModeratorSoftwarePage : SoftwarePage {

  public ModeratorSoftwarePage(User user) : base(user) {
    Button addButton = new Button { Content = "Add", Command = this.dataContext.Add };

    this.ActionBar.Controls.Add(addButton);
    this.DataGrid.MakeWritable();
    this.DataGrid.DeleteEntry += deleteEntry;
    addButton.SetResourceReference(Button.CommandParameterProperty, "Data");
  }
}

