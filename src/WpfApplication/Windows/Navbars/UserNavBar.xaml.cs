namespace WpfApplication;

using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

public class UserNavBar : Control {
  
  static UserNavBar() {
    DefaultStyleKeyProperty.OverrideMetadata(typeof(UserNavBar),
        new FrameworkPropertyMetadata(typeof(UserNavBar)));
  }

  // Contains Controls between which the user can switch
  public ObservableCollection<Control> Controls 
  {
    get { return (ObservableCollection<Control>)GetValue(ControlsProperty); }
    set { SetValue(ControlsProperty, value); }
  }

  public static readonly DependencyProperty ControlsProperty =
    DependencyProperty.Register("Controls", typeof(ObservableCollection<Control>),
        typeof(UserNavBar), new PropertyMetadata(null));

  public UserNavBar() : base() {
    this.Controls = new ObservableCollection<Control>();
  }
}
