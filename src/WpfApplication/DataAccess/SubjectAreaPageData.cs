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
