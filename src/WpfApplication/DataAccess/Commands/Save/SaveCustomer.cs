namespace DataAccess.Commands;


public class SaveCustomer : DBCommand {
  
  public SaveCustomer() : base() {}

  public override void Execute(object? param) {
    this.dbConnection.SaveChanges();
  }
  
}
