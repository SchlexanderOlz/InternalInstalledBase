/**
* @file
* @brief This file contains the definition of the UserTypeValueConverter class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Globalization;
using DapperExtension.DBContext.Models.Users;


/**
 * @brief Converts the UserType enum from its enum representation to an interger
 * and back
 */
public class UserTypeValueConverter : IValueConverter
{

  // Converts to int
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is UserType type)
    {
      return (int)type;
    }
    return Binding.DoNothing;
  }

  // Converts to UserType
  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is int index)
    {
      return (UserType)index;
    }
    return Binding.DoNothing;
  }
}
