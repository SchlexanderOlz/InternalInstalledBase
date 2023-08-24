namespace DapperExtension.DBContext.Models.Users;

using Microsoft.EntityFrameworkCore;
using System;

public class Session : IDataObject
{
  public int SessionId { get; set; }
  public DateTime BeginTime { get; set; }
  public DateTime EndTime { get; set; }
  public User User { get; set; }

  public Session(User user)
  {
    this.User = user;
  }

  internal Session() {}

  public void Start()
  {
    this.BeginTime = DateTime.Now;
  }

  public void End()
  {
    this.EndTime = DateTime.Now;
  }

  public void Up(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Session>(entityBuilder =>
    {
      entityBuilder.HasKey(e => e.SessionId);
      entityBuilder.Property(e => e.BeginTime)
        .IsRequired();
      entityBuilder.Property(e => e.EndTime)
        .IsRequired();
    });
  }
}
