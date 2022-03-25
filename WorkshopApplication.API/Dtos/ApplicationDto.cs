namespace WorkshopApplication.API.Dtos;

public class ApplicationDto
{
    public string Country { get; set; }
    public string University { get; set; }
    public string FieldOfStudy { get; set; }
    public string Reason { get; set; }
    public ParticipantDto Participant { get; set; }
    public WorkshopDto Workshop { get; set; }
}