namespace WpfApplication.UserControls;

using System.Windows.Controls;
using DapperExtension.DBContext.Models.Users;


public partial class UserContent : UserControl {
  private User user;

  public UserContent(User user) {
    this.user = user; 
  }
}
