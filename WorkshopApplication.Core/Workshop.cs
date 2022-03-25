namespace WorkshopApplication.Core;

public class Workshop : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public ICollection<Application> Applications { get; set; }
}