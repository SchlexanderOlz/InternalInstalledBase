using System;
using System.Windows;
using DataAccess;
using DataAccess.Commands;

namespace WpfApplication
{

  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      this.InitializeComponent();
      MainWindowData data = new();
      SubmitUser submitUser = data.SubmitUserCommand;
      this.DataContext = data;
      submitUser.LogonFailure += logonFailed;     
      submitUser.LogonSuccess += logon;
    }

    private void logonFailed(object sender, EventArgs e) {
      MessageBox.Show("Password or user not found!");
    }

    private void logon(object sender, LogonSuccessArgs args) {
      var content = new UserContentFactory().CreateUserContent(args.User);
      content.InitializeComponent();
      this.Content = content;
    }
  }
}
