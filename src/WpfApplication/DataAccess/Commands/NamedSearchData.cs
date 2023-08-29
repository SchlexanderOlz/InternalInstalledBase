/**
* @file
* @brief This file contains the definition of the NamedSearchData abstract class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess.Commands;


/**
 * @brief The NamedSearchData is an interface which contains the *Name* field
 */
public abstract class NamedSearchData 
{
  public string? Name { get; set; }

  public void Clean()
  {
    this.Name = null;
  }
}
