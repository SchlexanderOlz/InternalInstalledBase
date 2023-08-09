namespace DapperExtension.DBContext.Models.Users;

using Microsoft.EntityFrameworkCore;

public class Moderator : User
{
  public ICollection<DataChange> ?Changes {get; set; } 

  public Moderator(string name, string password, UserType userType) : base(name, password, userType) {}
  public Moderator() : base() {}

  public virtual void Up(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Moderator>(entityBuilder => {
            entityBuilder.HasMany(e => e.Changes)
               .WithOne(c => c.ChangeActor);
        });
  }
}
