/**
* @file
* @brief This file contains the definition of the HelpdeskStatusConverter class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Globalization;
using DapperExtension.DBContext.Models;


/**
 * @brief The HelpdeskStatusConverter is used to convert the enum to it's integer
 * representation and back to the enum-format
 */
public class HelpdeskStatusConverter : IValueConverter
{

  /**
   * @brief Converts to integer
   */
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is HelpDeskStatus status)
    {
      return (int)status;
    }
    return Binding.DoNothing;
  }

  /**
   * @brief Converts to HelpDeskStatus
   */
  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is int index)
    {
      return (HelpDeskStatus)index;
    }
    return Binding.DoNothing;
  }
}
