using Microsoft.EntityFrameworkCore;

internal interface IDataObject {
    void Up(ModelBuilder modelBuilder);
}