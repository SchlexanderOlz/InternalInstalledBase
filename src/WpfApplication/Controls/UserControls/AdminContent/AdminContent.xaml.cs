namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;


public partial class AdminContent : ModeratorContent {
  public AdminContent(User user) : base(user) {}
}
