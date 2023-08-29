/**
* @file
* @brief This file contains the definition of the MaterialNumberConverter class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Globalization;


/**
 * @brief Converts the MaterialNumber from its string representation ot an interger
 * and back
 */
public class MaterialNumberConverter : IValueConverter
{

  /**
   * @brief Converts to string 
   */
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is uint materialNumber)
    {
      return materialNumber.ToString();
    }
    return Binding.DoNothing;
  }

  /**
   * @brief Converts to uint
   */
  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is string materialString)
    {
      try
      {
        return uint.Parse(materialString);
      }
      catch (Exception)
      {
        return Binding.DoNothing;
      }
    }
    return Binding.DoNothing;
  }
}
