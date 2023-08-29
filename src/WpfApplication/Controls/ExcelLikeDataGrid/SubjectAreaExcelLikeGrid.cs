/**
 * @file
 * @brief This file contains the definition of the SubjectAreaExcelLikeGrid class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using DapperExtension.DBContext.Models;


public class SubjectAreaExcelLikeGrid : ExcelLikeDataGrid<SubjectArea>
{
  public SubjectAreaExcelLikeGrid(ObservableCollection<SubjectArea> itemSource) : base(itemSource)
  {
    this.dataGrid.Columns.Add(new DataGridTextColumn
    {
      Header = "Name",
      Binding = new Binding("Name")
    });

  }

  static SubjectAreaExcelLikeGrid() { }
}
