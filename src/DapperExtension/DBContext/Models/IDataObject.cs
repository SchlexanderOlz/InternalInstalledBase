using Microsoft.EntityFrameworkCore;


namespace DapperExtension.DBContext;

internal interface IDataObject
{
    void Up(ModelBuilder modelBuilder);
}