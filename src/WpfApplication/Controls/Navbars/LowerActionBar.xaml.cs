namespace WpfApplication;

using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

public class LowerActionBar : Control {
  
  static LowerActionBar() {
    DefaultStyleKeyProperty.OverrideMetadata(typeof(LowerActionBar),
        new FrameworkPropertyMetadata(typeof(LowerActionBar)));
  }

  public ObservableCollection<Control> Controls 
  {
    get { return (ObservableCollection<Control>)GetValue(ControlsProperty); }
    set { SetValue(ControlsProperty, value); }
  }

  public static readonly DependencyProperty ControlsProperty =
    DependencyProperty.Register("Controls", typeof(ObservableCollection<Control>),
        typeof(LowerActionBar), new PropertyMetadata(null));

  public LowerActionBar() : base() {
    this.Controls = new ObservableCollection<Control>();
  }
}
