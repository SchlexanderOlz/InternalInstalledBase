namespace DataAccess.Commands;

using System.Collections.Generic;
using DapperExtension.DBContext.Models;
using System;


public class PropertyData : NamedSearchData, ISearchData
{
  public string? Options { get; set; }
  public bool? IsMultipleChoice { get; set; }
  public ICollection<Product>? Products { get; set; }

  public void Clear()
  {
    this.Options = null;
    this.Products = null;
    this.IsMultipleChoice = null;
  }

  public ICollection<Option> ParseOptions()
  {
    if (this.Options == null)
    {
      throw new InvalidOperationException();
    }

    ICollection<string> args = this.Options.Split(";");

    List<Option> options = new();
    foreach(var arg in args) {
      Option option = new(arg.Trim());
      options.Add(option);
    }

    return options;
  }

}
