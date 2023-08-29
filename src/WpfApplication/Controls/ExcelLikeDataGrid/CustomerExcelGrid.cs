/**
 * @file
 * @brief This file contains the definition of the CustomerExcelGrid class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


/**
 * @brief ExcelGrid for the customer
 */
public class CustomerExcelLikeGrid : DescriptableExcelLikeGrid<Customer>
{
  public CustomerExcelLikeGrid(ObservableCollection<Customer> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn { Header = "Helpdesk Status", Binding = new Binding("DeskStatus") });

    var actionsColumn = new DataGridTemplateColumn { Header = "Actions" };
    actionsColumn.CellTemplate = new DataTemplate();

    // The stackPanelFactory is used to attach buttons into one column (actionsColumn)
    var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
    stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

    var showInterestsButtonFactory = new FrameworkElementFactory(typeof(Button));
    showInterestsButtonFactory.SetValue(Button.ContentProperty, "Show Interests");
    showInterestsButtonFactory.AddHandler(Button.ClickEvent,
        new RoutedEventHandler(loadSubjectAreaList));

    stackPanelFactory.AppendChild(showInterestsButtonFactory);

    var showProductsButtonFactory = new FrameworkElementFactory(typeof(Button));
    showProductsButtonFactory.SetValue(Button.ContentProperty, "Show Products");
    showProductsButtonFactory.AddHandler(Button.ClickEvent,
        new RoutedEventHandler(loadProductList));

    stackPanelFactory.AppendChild(showProductsButtonFactory);

    // Here the elements of the stackPanelFactory are attached
    actionsColumn.CellTemplate.VisualTree = stackPanelFactory;

    this.dataGrid.Columns.Add(actionsColumn);
  }

  /**
   * @brief Loads the page of associated products of the customer,
   * currently selected in the ExcelGrid
   *    -> Handles an Event
   */
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
    }
    else
    {
      data = new(customer.Products);
    }
    ProductAddSearchPage gridWindow = new(customer);
    gridWindow.Show();
  }

  /**
   * @brief Loads the page of associated SubjectAreas of the customer,
   * currently selected in the ExcelGrid
   *    -> Handles an Event
   */
  private void loadSubjectAreaList(object sender, RoutedEventArgs e)
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

    ObservableCollection<SubjectArea> data;
    if (customer.Products == null)
    {
      data = new();
    }
    else
    {
      data = new(customer.SubjectAreas);
    }
    SubjectAreaAddSearch gridWindow = new(customer);
    gridWindow.Show();

  }
  // Static constructor needed to use component in .xaml
  static CustomerExcelLikeGrid() { }
}
