/**
 * @file
 * @brief This file contains the definition of the AddProperty class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using System;
using System.Collections.Generic;
using DapperExtension.DBContext.Models;

public class AddProperty : AddCommand
{
  public AddProperty() : base() { }

  public override void Execute(object param)
  {
    PropertyData propertyData = (PropertyData)param;

    if (isNull(propertyData.Name) || propertyData.IsMultipleChoice == null
        || isNull(propertyData.Options)) {
      OnAddFailed(new ErrorEventArgs("Some property was not supplied"));
      return;
    }
    Property property = new(propertyData.Name, propertyData.IsMultipleChoice.Value);

    ICollection<Option> options = propertyData.ParseOptions();

    try {
      this.dbConnection.InsertPropertyOptionPack(property, options);
      OnAddSuccessfull();
    } catch (Exception e)
    {
      OnAddFailed(new ErrorEventArgs(e.Message));
    }
  }
}
