namespace WpfApplication.Pages;

using DapperExtension.DBContext.Models;

public partial class ProductPage : ContentPage<Product> {
  public ProductPage() : base(new ProductPageData()) {
    
  }
}
