/**
 * @file
 * @brief This file contains the definition of the UserDoesNotExistException exception
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models.Users;

class UserDoesNotExistException : Exception
{
    private const string message = "User does not exist! Password or Username is Wrong";
    public UserDoesNotExistException(string message = message) : base(message) { }
}
