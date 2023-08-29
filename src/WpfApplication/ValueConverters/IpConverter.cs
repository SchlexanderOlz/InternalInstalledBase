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


/**
 * @brief The IpConverter is used to convert an Ip from it's string representation
 * to it's byte representation and back
 */
public class IpConverter : IValueConverter
{

  /**
   * @brief Converts to uint (byte-representation)
   */
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is uint ipAddr)
    {
      string ipString = "";
      while (ipAddr != 0)
      {
        // Gets the 8 leftmost bits
        byte right = (byte)(ipAddr & 0xFF);
        ipString = right + (ipString.Length > 0 ? "." : "") + ipString;
        // Move 8 bits to the right replacing all 8 bits on the left with zeros
        ipAddr >>= 8;
      }
      return ipString;
    }
    return Binding.DoNothing;
  }

  /**
   * @brief Converts to string
   */
  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is string ipString)
    {
      string[] addrParts = ipString.Split(".");
      if (addrParts.Length != 4)
      {
        return Binding.DoNothing;
      }

      uint ipInt = 0;
      foreach (var part in addrParts)
      {
        byte num = 0;
        try
        {
          num = byte.Parse(part);
        }
        catch (Exception ex) when (ex is FormatException || ex is OverflowException)
        {
          return Binding.DoNothing;
        }
        // Moves the address to the left and move the *num* into the newly created
        // 8 zero-bits on the right
        ipInt = (ipInt << 8) | num;
      }
      return ipInt;
    }
    return Binding.DoNothing;
  }
}
