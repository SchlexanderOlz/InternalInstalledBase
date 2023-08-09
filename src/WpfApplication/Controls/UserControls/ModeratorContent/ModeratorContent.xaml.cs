namespace WpfApplication.UserControls;

using DapperExtension.DBContext.Models.Users;

public partial class ModeratorContent : UserContent {

  public ModeratorContent(User user) : base(user) {}
}
