namespace DapperExtension.DBContext.Models.Users;

using Microsoft.EntityFrameworkCore; 

public class DataChange : IDataObject {

  public int DataChangeId { get; set; }
  public string Table {get; set; }
  public string ChangedContent {get; set; }
  public ActionType ActionType {get; set; }
  public Moderator ChangeActor { get; set; }
  public DateTime TimeStamp { get; set; }

  public void Up(ModelBuilder modelBuilder) {
    modelBuilder.Entity<DataChange>(entityBuilder => {
        entityBuilder.HasKey(e => e.DataChangeId);
        entityBuilder.Property(e => e.Table)
          .IsRequired();
        entityBuilder.Property(e => e.ChangedContent)
          .IsRequired();
        entityBuilder.Property(e => e.ActionType)
          .IsRequired();
        entityBuilder.Property(e => e.TimeStamp)
          .IsRequired();
      }); 
  }
}

public enum ActionType {
  INSERT,
  UPDATE,
}
