namespace DapperExtension.DBContext.Models.Users;

using Microsoft.EntityFrameworkCore;

public class Moderator : User
{
  public ICollection<DataChange> ?Changes {get; set; } 

  public override void Up(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Moderator>(entityBuilder => {
            entityBuilder.HasMany(e => e.Changes)
               .WithOne(c => c.ChangeActor);
        });
  }
}
