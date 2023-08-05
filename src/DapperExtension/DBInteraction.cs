namespace DapperExtension;

using DapperExtension.DBContext;
public class DBInteraction
{
    private readonly InventoryManagementContext model;

    public DBInteraction() {
        this.model = new InventoryManagementContext();
        this.model.Database.EnsureCreated();
    }
}
