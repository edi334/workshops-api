namespace WorkshopApplication.API.Dtos;

public class ApplicationRequestDto : ApplicationDto
{
    public string ParticipantId { get; set; }
    public string WorkshopId { get; set; }
}