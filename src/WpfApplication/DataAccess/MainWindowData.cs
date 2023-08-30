/**
* @file
* @brief This file contains the definition of the MainWindowData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess;

using Commands;


/**
 * @brief The MainWindowData contains all commands for the MainWindow class
 */
public class MainWindowData
{
  public SubmitUser SubmitUserCommand { get; set; }
  public AddSession AddSessionCommand { get; set; }
  public CheckUsersExisting CheckUsersExistingCommand { get; set; }

  public MainWindowData()
  {
    this.CheckUsersExistingCommand = new();
    this.CheckUsersExistingCommand.Execute(null);

    this.SubmitUserCommand = new();
    this.AddSessionCommand = new();
  }

}
