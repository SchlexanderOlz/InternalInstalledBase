using System;
using System.Windows;
using DataAccess;
using WpfApplication.UserControls;
using DataAccess.Commands;
using DapperExtension.DBContext.Models.Users;

namespace WpfApplication
{
 
  public partial class MainWindow : Window
  {
    private object? content;
    private MainWindowData dataContext; 
    public MainWindow()
    {
      this.InitializeComponent();
      this.content = Content;

      MainWindowData data = new();
      SubmitUser submitUser = data.SubmitUserCommand;

      this.DataContext = data;
      this.dataContext = data;

      submitUser.LogonFailure += logonFailed;     
      submitUser.LogonSuccess += logon;
    }

    private void logonFailed(object sender, EventArgs e) {
      MessageBox.Show("User not found!");
    }

    private void logon(object sender, Session args) {
      UserContent content = new UserContentFactory().CreateUserContent(args);
      content.InitializeComponent();

      content.Back += logout;
      this.Content = content;
    }

    private void logout(object? sender, Session session)
    {
      session.End();
      this.dataContext.AddSessionCommand.Execute(session);
      this.Content = this.content;
    }

    private void passwordChanged(object sender, RoutedEventArgs args)
    {
      UserCredentials credentials = (UserCredentials)((FrameworkElement)sender).FindResource("Credentials");
      credentials.Password = passwordBox.Password;
    }
  }
}
