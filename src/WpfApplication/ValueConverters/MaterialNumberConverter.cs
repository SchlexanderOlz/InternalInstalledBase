namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Globalization;

public class MaterialNumberConverter : IValueConverter
{

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is uint materialNumber)
    {
      return materialNumber.ToString();
    }
    return Binding.DoNothing;
  }

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
