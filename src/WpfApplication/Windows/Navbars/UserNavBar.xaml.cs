namespace WpfApplication;

using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

public class UserNavBar : Control {
  
  static UserNavBar() {
    DefaultStyleKeyProperty.OverrideMetadata(typeof(UserNavBar),
        new FrameworkPropertyMetadata(typeof(UserNavBar)));
  }

  // Contains Windows between which the user can switch
  public ObservableCollection<Window> Windows
  {
    get { return (ObservableCollection<Window>)GetValue(WindowsProperty); }
    set { SetValue(WindowsProperty, value); }
  }

  public static readonly DependencyProperty WindowsProperty =
    DependencyProperty.Register("Windows", typeof(ObservableCollection<Window>),
        typeof(UserNavBar), new PropertyMetadata(null));

  public UserNavBar() {
    this.Windows = new ObservableCollection<Window>();
  }
}
