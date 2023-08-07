namespace DapperExtension.DBContext.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

public class User : IDataObject {
    public int UserId { get; set; }
    public string UserName {get; set; }
    public string Password { get; set;}
    public UserType UserType { get; set; }
    public ICollection<Session> ?Sessions { get; set; }

    public virtual void Up(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>(entityBuilder => {
            entityBuilder.HasKey(e => e.UserId);
            entityBuilder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
            entityBuilder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength();
            entityBuilder.Property(e => e.UserType)
                .IsRequired()
                .HasDefaultValue(UserType.kUser);
            entityBuilder.HasMany(e => e.Sessions)
              .WithOne(s => s.User);
        });
    }
}

public enum UserType {
    kUser,
    kModerator,
    kAdmin
}
