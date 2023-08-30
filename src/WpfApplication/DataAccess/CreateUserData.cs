/**
* @file
* @brief This file contains the definition of the CreateUserData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess;

using Commands;


/**
 * @brief The CreateUserData contains all commands for the CreateUser class
 */
public class CreateUserData 
{
  public AddUser AddUser { get; set; }
  public CreateUserData()
  {
    this.AddUser = new();
  }
}
