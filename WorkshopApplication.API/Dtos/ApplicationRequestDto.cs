namespace WorkshopApplication.API.Dtos;

public class ApplicationRequestDto : ApplicationDto
{
    public Guid ParticipantId { get; set; }
    public Guid WorkshopId { get; set; }
}