/**
 * @file
 * @brief This file contains the definition of the IDataObject interface 
 * @author Alexander Scholz
 * @date 29-08-2023
 */
using Microsoft.EntityFrameworkCore;


namespace DapperExtension.DBContext;

internal interface IDataObject
{
    void Up(ModelBuilder modelBuilder);
}
