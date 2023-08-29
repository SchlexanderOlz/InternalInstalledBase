/**
 * @file
 * @brief This file contains the definition of the Session class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
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

  // Sets the BeginTime to the currentTime
  public void Start()
  {
    this.BeginTime = DateTime.Now;
  }

  // Sets the EndTime to the currentTime
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
