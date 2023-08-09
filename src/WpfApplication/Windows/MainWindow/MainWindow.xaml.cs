using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Commands;
using DapperExtension.DBContext.Models.Users;

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

    private void logon(object sender, EventArgs e) {
      LogonSuccessArgs? args = e as LogonSuccessArgs; 
      if (args == null) {
        throw new InvalidOperationException(
            $"The event-argument given did not match the expecte type ({typeof(LogonSuccessArgs)})"
        );
      }
      var content = new UserContentFactory().CreateUserContent(args.User);
      this.Content = content;
    }
  }
}
