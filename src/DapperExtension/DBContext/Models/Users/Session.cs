namespace DapperExtension.DBContext.Models.Users;

using Microsoft.EntityFrameworkCore;
using System;

public class Session : IDataObject {
  public int SessionId { get; set; }
  public DateTime Begin { get; set; }
  public DateTime End { get; set; }
  public User User { get; set; } 

  public void Up(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Session>(entityBuilder => {
            entityBuilder.HasKey(e => e.SessionId);
            entityBuilder.Property(e => e.Begin)
              .IsRequired();
            entityBuilder.Property(e => e.End)
              .IsRequired();
        });
  }
}
