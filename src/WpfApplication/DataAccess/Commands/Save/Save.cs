/**
 * @file
 * @brief This file contains the definition of the Save class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;


/**
 * @brief The generall save command just calls the SaveChanges method of the dataBase
 */
public class Save : DBCommand
{

  public Save() : base() { }

  public override void Execute(object? param)
  {
    this.dbConnection.SaveChanges();
  }

}
