namespace DataAccess;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Commands;
using DapperExtension.DBContext.Models.Users;
using DapperExtension;

public class MainWindowData : INotifyPropertyChanged {

  public ICommand SubmitUserCommand; 

  public MainWindowData() {

  }
  
  public event PropertyChangedEventHandler PropertyChanged;

  protected void OnPropertyChanged([CallerMemberName] string propertyName = "") { 
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
