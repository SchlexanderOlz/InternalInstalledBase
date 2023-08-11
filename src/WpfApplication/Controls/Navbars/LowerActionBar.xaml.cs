namespace WpfApplication;

using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

public class LowerActionBar : Control {
  
  static LowerActionBar() {
    DefaultStyleKeyProperty.OverrideMetadata(typeof(LowerActionBar),
        new FrameworkPropertyMetadata(typeof(LowerActionBar)));
  }

  public ObservableCollection<Control> ActionControls 
  {
    get { return (ObservableCollection<Control>)GetValue(ActionControlsProperty); }
    set { SetValue(ActionControlsProperty, value); }
  }

  public static readonly DependencyProperty ActionControlsProperty =
    DependencyProperty.Register("ActionControls", typeof(ObservableCollection<Control>),
        typeof(LowerActionBar), new PropertyMetadata(null));

  public LowerActionBar() : base() {
    this.ActionControls = new ObservableCollection<Control>();
  }
}
