namespace DataAccess.Commands;


public class Save : DBCommand {
  
  public Save() : base() {}

  public override void Execute(object? param) {
    this.dbConnection.SaveChanges();
  }
  
}
