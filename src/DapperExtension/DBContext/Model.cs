using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DapperExtension.DBContext;
using Models;
public class InventoryManagementContext : DbContext {

    public DbSet<Customer> customers {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
              {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
              } 
              );
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseMySQL("server=localhost;database=IIB;user=user;password=tmp");
        } 
}
