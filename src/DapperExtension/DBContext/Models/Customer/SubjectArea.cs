namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;

public class SubjectArea : IDataObject
{
    public int SubjectAreaId { get; set; }
    public string Name { get; set; }

    public SubjectArea(string name) : base() {
      this.Name = name;
    }

    internal SubjectArea() {}

    public void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectArea>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.SubjectAreaId);
        }
        );
    }

}
