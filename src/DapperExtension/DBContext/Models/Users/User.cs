/**
 * @file
 * @brief This file contains the definition of the User class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

/**
 * @brief User implements the IDataObject interface
 *    -> User is the type which is used to manage logon and sessions
 */
public class User : IDataObject
{
    public int? UserId { get; set; }
    public string UserName { get; set; }
    public byte[] Password { get; set; }
    public UserType UserType { get; set; }
    public ICollection<Session>? Sessions { get; set; }
    public ICollection<DataChange>? Changes { get; set; }

    public User(string userName, string password, UserType userType)
    {
        this.UserName = userName;
        this.Password = User.HashPassword(password);
        this.UserType = userType;
    }

    public User() { }

    /**
     * @brief Hashes the password
     * @param password The password by reference which will be hashed
     * @return The SHA256 hash of the password
     */
    public static byte[] HashPassword(in string password)
    {
        return SHA256.HashData(Encoding.UTF8.GetBytes(password));
    }

    public void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.UserId);
            entityBuilder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
            entityBuilder.Property(e => e.Password)
                .IsRequired();
            entityBuilder.Property(e => e.UserType)
                .IsRequired()
                .HasDefaultValue(UserType.User);
            entityBuilder.HasMany(e => e.Sessions)
              .WithOne(s => s.User);
            entityBuilder.HasMany(e => e.Changes)
              .WithOne(c => c.User);
        });
    }
}

public enum UserType
{
    User,
    Moderator,
    Admin
}
