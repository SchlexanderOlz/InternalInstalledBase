namespace WpfApplication;

using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;
using WpfApplication.Pages;
using System;


public class CustomerExcelLikeGrid : DescriptableExcelLikeGrid<Customer> 
{
  public CustomerExcelLikeGrid(ObservableCollection<Customer> itemSource) : base(itemSource) {
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
        showProductsButtonFactory.AddHandler(Button.ClickEvent,
            new RoutedEventHandler(loadProductList));

        stackPanelFactory.AppendChild(showProductsButtonFactory);

        actionsColumn.CellTemplate.VisualTree = stackPanelFactory;

        this.dataGrid.Columns.Add(actionsColumn);
  }

  protected void loadProductList(object sender, RoutedEventArgs e)
  {
    Button? button = sender as Button;
    if (button == null)
    {
      return;
    }

    Customer? customer = button?.DataContext as Customer;
    if (customer == null)
    {
      return;
    }
    
    ObservableCollection<Product> data;
    if (customer.Products == null)
    {
      data = new();
    } else
    {
      data = new(customer.Products);
    }
    ProductDataGridWindow gridWindow = new(new ObservableCollection<Product>());
    gridWindow.Show();
  }

  static CustomerExcelLikeGrid() {}
}
