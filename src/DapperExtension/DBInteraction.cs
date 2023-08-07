namespace DapperExtension;

using DapperExtension.DBContext;
using System.Security.Cryptography;
using System.Text;
using DBContext.Models.Users;
using DBContext.Models;

public class DBInteraction
{
    private readonly InventoryManagementContext context;

    public DBInteraction()
    {
        this.context = new InventoryManagementContext();
        this.context.Database.EnsureCreated();
    }

    public void InsertProduct(Product product)
    {
        this.context.Products.Add(product);
        this.context.SaveChanges();
    }

    public void InsertHarware(Hardware hardware) {
      this.context.Hardware.Add(hardware);
      this.context.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return this.context.Products.Select(p => p).ToList();
    }

    public User GetUserByCredentials(string username, string password)
    {
        try
        {
            string passwordHash = DBInteraction.HashPassword(in password);
            return this.context.Users
                .Select(u => u)
                .Where(u => u.UserName == username && u.Password == passwordHash)
                .First();
        }
        catch (ArgumentNullException)
        {
            throw new UserDoesNotExistException();
        }
    }

    public static string HashPassword(in string password)
    {
        byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder stringBuilder = new();
        foreach (byte b in hashedBytes)
        {
            stringBuilder.Append(b);
        }
        return stringBuilder.ToString();
    }

}
