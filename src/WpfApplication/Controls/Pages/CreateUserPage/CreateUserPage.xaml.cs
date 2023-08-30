/**
 * @file
 * @brief This file contains the definition of the CreateUserPage class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace WpfApplication.Pages;

using DataAccess;
using System;
using System.Windows.Controls;
using DataAccess.Commands;
using DapperExtension.DBContext.Models.Users;


public partial class CreateUserPage : UserControl
{
  public event EventHandler Back;
  public CreateUserPage() : base()
  {
    this.InitializeComponent();

    CreateUserData data = new();
    data.AddUser.AddSuccess += OnBack;
    this.DataContext = data;

    var staticData = (UserData)this.submitButton.FindResource("Data");
    staticData.UserType = UserType.Admin;
  }

  protected void OnBack(object? sender, EventArgs? e)
  {
    this.Back?.Invoke(this, EventArgs.Empty);
  }
}
