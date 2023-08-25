namespace DataAccess.Commands;

using System;

public class AddProperty : AddCommand
{
  public AddProperty() : base() { }

  public override void Execute(object param)
  {
    PropertyData property = (PropertyData)param;
    throw new NotImplementedException();
  }
}
