namespace DapperExtension.DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SubjectArea : IDataObject
{
    public int SubjectAreaId { get; set; }

    public void Up(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectArea>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.SubjectAreaId);
        }
        );
    }

}