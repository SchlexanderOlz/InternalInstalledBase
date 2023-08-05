namespace DapperExtension.DBContext.Models.Users;
using Microsoft.EntityFrameworkCore;

public class User : IDataObject {
    public int UserId { get; set; }
    public string UserName { get; set;}
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public string Password { get; set;}
    public UserType UserType { get; set; }

    public void Up(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>(entityBuilder => {
            entityBuilder.HasKey(e => e.UserId);
            entityBuilder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
            entityBuilder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            entityBuilder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);
            entityBuilder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength();
            entityBuilder.Property(e => e.UserType)
                .IsRequired()
                .HasDefaultValue(UserType.kUser);
        });
    }
}

public enum UserType {
    kUser,
    kModerator,
    kAdmin
}