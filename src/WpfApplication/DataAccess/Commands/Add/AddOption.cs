/**
 * @file
 * @brief This file contains the definition of the AddOption class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DataAccess.Commands;

using DapperExtension.DBContext.Models;
using System;

public class AddOption : AddCommand
{
  public AddOption() : base() { }

  public override void Execute(object? param)
  {
    OptionData? optionData = param as OptionData;
    if (optionData == null)
    {
      OnAddFailed(new ErrorEventArgs($"Data passed to Execute was not typeof {typeof(OptionData)}"));
      return;
    }

    if (isNull(optionData.Name) || optionData.Property == null)
    {
      OnAddFailed(new ErrorEventArgs("Missing name field"));
      return;
    }

    try {
      this.dbConnection.InsertOption(new Option(optionData.Name, optionData.Property));
      OnAddSuccessfull();
    } catch (InvalidOperationException ex)
    {
      OnAddFailed(new ErrorEventArgs(ex.Message));
    }
  }
}
