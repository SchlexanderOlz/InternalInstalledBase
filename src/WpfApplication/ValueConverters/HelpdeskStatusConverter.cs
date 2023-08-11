namespace WpfApplication.ValueConverters;

using System.Windows.Data;
using System;
using System.Windows;
using System.Globalization;
using DapperExtension.DBContext.Models;

public class HelpdeskStatusConverter : IValueConverter {

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    if (value is HelpDeskStatus status) 
    {
      return (int)status;
    }
    return Binding.DoNothing;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is int index)
    {
      return (HelpDeskStatus)index;
    }
    return Binding.DoNothing;
  }
} 
