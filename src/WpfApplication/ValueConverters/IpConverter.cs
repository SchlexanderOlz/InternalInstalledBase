namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Globalization;

public class IpConverter : IValueConverter
{

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is uint ipAddr)
    {
      string ipString = "";
      while (ipAddr != 0)
      {
        byte right = (byte)(ipAddr & 0xFF);
        ipString = right + (ipString.Length > 0 ? "." : "") + ipString;
        ipAddr >>= 8;
      }
      return ipString;
    }
    return Binding.DoNothing;
  }

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
        ipInt = (ipInt << 8) | num;
      }
      return ipInt;
    }
    return Binding.DoNothing;
  }
}
