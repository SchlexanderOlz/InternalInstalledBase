namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using System.Windows;


public class PropertyExcelGrid : ExcelLikeDataGrid<Property>
{
  public PropertyExcelGrid(ObservableCollection<Property> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Name",
      Binding = new Binding("Name")
    });

    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "MultipleChoice",
      Binding = new Binding("IsMultipleChoice")
    });

    var actionsColumn = new DataGridTemplateColumn { Header = "Actions" };
    actionsColumn.CellTemplate = new DataTemplate();

    var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
    stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

    var showBF= new FrameworkElementFactory(typeof(Button));
    showBF.SetValue(Button.ContentProperty, "Show Options");
    showBF.AddHandler(Button.ClickEvent,
        new RoutedEventHandler(loadOptionsList));

    stackPanelFactory.AppendChild(showBF);

    actionsColumn.CellTemplate.VisualTree = stackPanelFactory;

    this.dataGrid.Columns.Add(actionsColumn);

  }

  protected void loadOptionsList(object sender, RoutedEventArgs e)
  {
    Button? button = sender as Button;
    if (button == null)
    {
      return;
    }

    Property? property = button?.DataContext as Property;
    if (property == null)
    {
      return;
    }

    ObservableCollection<Option> data;
    if (property.Options == null)
    {
      data = new();
    }
    else
    {
      data = new(property.Options);
    }
    OptionAddSearchPage gridWindow = new(property);
    gridWindow.Show();
  }


  static PropertyExcelGrid() { }
}
