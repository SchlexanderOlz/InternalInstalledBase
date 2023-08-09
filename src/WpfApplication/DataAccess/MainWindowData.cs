namespace DataAccess;

using System.Windows.Input;
using Commands;
using System.Windows;
using System;

public class MainWindowData {

  public SubmitUser SubmitUserCommand { get; set; } 

  public MainWindowData() {
      this.SubmitUserCommand = new SubmitUser();
  }

}
