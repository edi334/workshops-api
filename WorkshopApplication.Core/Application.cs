namespace WorkshopApplication.Core;

public class Application
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string University { get; set; }
    public string FieldOfStudy { get; set; }
    public string Reason { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
    public Workshop Workshop { get; set; }
}