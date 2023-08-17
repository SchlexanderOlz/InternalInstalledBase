namespace WpfApplication;

using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class CustomerExcelLikeGrid : ExcelLikeDataGrid<Customer>
{
  public CustomerExcelLikeGrid(ObservableCollection<Customer> itemSource) : base(itemSource) {
        this.dataGrid.ItemsSource = itemSource;
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Description", Binding = new Binding("Description") });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Shortcut", Binding = new Binding("Shortcut") });
        this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Helpdesk Status", Binding = new Binding("DeskStatus") });

        var actionsColumn = new DataGridTemplateColumn { Header = "Actions" };
        actionsColumn.CellTemplate = new DataTemplate();

        var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
        stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

        var showInterestsButtonFactory = new FrameworkElementFactory(typeof(Button));
        showInterestsButtonFactory.SetValue(Button.ContentProperty, "Show Interests");
        stackPanelFactory.AppendChild(showInterestsButtonFactory);

        var showProductsButtonFactory = new FrameworkElementFactory(typeof(Button));
        showProductsButtonFactory.SetValue(Button.ContentProperty, "Show Products");
        stackPanelFactory.AppendChild(showProductsButtonFactory);

        actionsColumn.CellTemplate.VisualTree = stackPanelFactory;

        this.dataGrid.Columns.Add(actionsColumn);
  }

  public void MakeReadOnly() {
    this.dataGrid.IsReadOnly = true;
  }

  public void MakeWritable() {
    this.dataGrid.IsReadOnly = false;
  }

  static CustomerExcelLikeGrid() {}
}
