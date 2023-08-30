/**
* @file
* @brief This file contains the definition of the MainWindow class 
* @author Alexander Scholz
* @date 29-08-2023
*/
using System;
using System.Windows;
using DataAccess;
using WpfApplication.UserControls;
using WpfApplication.Pages;
using DataAccess.Commands;
using DapperExtension.DBContext.Models.Users;

namespace WpfApplication;

/**
 * @brief Entry point of the application. Is a login-window
 */
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
    data.CheckUsersExistingCommand.UsersNonExistant += loadNewUserPage;
    data.CheckUsersExistingCommand.Execute(null);

    this.DataContext = data;
    this.dataContext = data;

    submitUser.LogonFailure += logonFailed;     
    submitUser.LogonSuccess += logon;
  }

  protected void loadNewUserPage(object sender, EventArgs e)
  {
    this.content = this.Content;
    CreateUserPage page = new CreateUserPage();
    this.Content = page;
    page.Back += this.reload;
  }

  /**
   * @brief Displays Logon error
   */
  private void logonFailed(object sender, EventArgs e) {
    MessageBox.Show("User not found!");
  }

  /**
   * @brief Loads the user-specific page
   */
  private void logon(object sender, Session args) {
    UserContent content = new UserContentFactory().CreateUserContent(args);
    content.InitializeComponent();

    content.Back += logout;
    this.passwordBox.Clear();
    this.Content = content;
  }

  /**
   * @brief Reloads the logon page 
   */
  private void logout(object? sender, Session session)
  {
    session.End();
    this.dataContext.AddSessionCommand.Execute(session);
    this.reload(null, null);
  }

  private void reload(object? sender, EventArgs? e)
  {
    this.Content = this.content;
  }

  /**
   * @brief Updates the staticressource when the user-type something 
   */
  private void passwordChanged(object sender, RoutedEventArgs args)
  {
    UserCredentials credentials = (UserCredentials)((FrameworkElement)sender).FindResource("Credentials");
    credentials.Password = passwordBox.Password;
  }
}
