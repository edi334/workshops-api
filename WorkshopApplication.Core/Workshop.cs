namespace WorkshopApplication.Core;

public class Workshop
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public ICollection<Application> Applications { get; set; }
}