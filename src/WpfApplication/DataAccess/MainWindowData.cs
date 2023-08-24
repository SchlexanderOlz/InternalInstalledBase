namespace DataAccess;

using Commands;

public class MainWindowData
{

  public SubmitUser SubmitUserCommand { get; set; }
  public AddSession AddSessionCommand { get; set; }

  public MainWindowData()
  {
    this.SubmitUserCommand = new();
    this.AddSessionCommand = new();
  }
}
