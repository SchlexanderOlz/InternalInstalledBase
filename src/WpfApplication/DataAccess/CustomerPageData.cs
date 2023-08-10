namespace DataAccess;

using Commands;

public class CustomerPageData : IPageData {

  public SearchCustomer SearchCustomer { get; set; } 

  public CustomerPageData() {
    this.SearchCustomer = new(); 
  }

}
