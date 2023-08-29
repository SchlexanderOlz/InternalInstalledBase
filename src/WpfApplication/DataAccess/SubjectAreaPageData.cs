/**
* @file
* @brief This file contains the definition of the SubjectAreaPageData class 
* @author Alexander Scholz
* @date 29-08-2023
*/
namespace DataAccess;

using Commands;
using DapperExtension.DBContext.Models;

public class SubjectAreaPageData : PageData<SubjectArea>
{
  public SubjectAreaPageData() : base(new Save(), new AddSubjectArea(),
      new SearchSubjectArea(), new DeleteSubjectArea())
  {

  }

}
