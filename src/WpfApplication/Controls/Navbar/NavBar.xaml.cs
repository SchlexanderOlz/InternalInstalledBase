/**
 * @file
 * @brief This file contains the definition of the NavBar class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication;

using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;


/**
 * @brief NavBar is a container which holds controls (usually buttons) in a horizontal way
 */
public class NavBar : ContentControl
{
  static NavBar()
  {
    DefaultStyleKeyProperty.OverrideMetadata(typeof(NavBar),
        new FrameworkPropertyMetadata(typeof(NavBar)));
  }

  public ObservableCollection<Control> Controls
  {
    get { return (ObservableCollection<Control>)GetValue(ControlsProperty); }
    set { SetValue(ControlsProperty, value); }
  }

  public static readonly DependencyProperty ControlsProperty =
    DependencyProperty.Register("Controls", typeof(ObservableCollection<Control>),
        typeof(NavBar), new PropertyMetadata(null));

  public NavBar() : base()
  {
    this.Controls = new ObservableCollection<Control>();
  }
}
