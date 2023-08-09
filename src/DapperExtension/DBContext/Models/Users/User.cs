namespace DapperExtension.DBContext.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

public class User : IDataObject {
    public int? UserId { get; set; }
    public string UserName {get; set; }
    public byte[] Password { get; set;}
    public UserType UserType { get; set; }
    public ICollection<Session> ?Sessions { get; set; }

    public User(string userName, string password, UserType userType) 
    { 
      this.UserName = userName;
      this.Password = User.HashPassword(password);
      this.UserType = userType;
    }

    public User() {}

    public static byte[] HashPassword(in string password) {
      return SHA256.HashData(Encoding.UTF8.GetBytes(password));
    }

    public void Up(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>(entityBuilder => {
            entityBuilder.HasKey(e => e.UserId);
            entityBuilder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
            entityBuilder.Property(e => e.Password)
                .IsRequired();
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
