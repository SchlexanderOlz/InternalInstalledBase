namespace DapperExtension.DBContext.Models;

class Customer
{
    public int ID { get; set; }

    public string Name { get; set; }
    public string Shortcut { get; set; }
    public List<SubjectArea> SubjectAreas { get; set; }

    public HelpDeskStatus DeskStatus { get; set; }

    public string Description { get; set; }

}

public enum HelpDeskStatus
{
    kTransmitted,
    kTemporaryTransmitted,
    kNotTransmitted
}
