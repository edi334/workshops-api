namespace WorkshopApplication.API.Dtos;

public class ApplicationResponseDto : ApplicationDto
{
    public ParticipantDto Participant { get; set; }
    public WorkshopDto Workshop { get; set; }
}