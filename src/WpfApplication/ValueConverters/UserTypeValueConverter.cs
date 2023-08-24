namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Globalization;
using DapperExtension.DBContext.Models.Users;

public class UserTypeValueConverter : IValueConverter
{

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is UserType type)
    {
      return (int)type;
    }
    return Binding.DoNothing;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is int index)
    {
      return (UserType)index;
    }
    return Binding.DoNothing;
  }
}
