/**
 * @file
 * @brief This file contains the definition of the SubjectArea class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;

public class SubjectArea : IDataObject
{
    public int SubjectAreaId { get; set; }
    public string Name { get; set; }
    public ICollection<Customer> Customers { get; set; }

    public SubjectArea(string name, ICollection<Customer> customers) : base()
    {
        this.Name = name;
        this.Customers = customers;
    }

    internal SubjectArea() { }

    public void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectArea>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.SubjectAreaId);
        }
        );
    }

}
