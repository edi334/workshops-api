using System.ComponentModel.DataAnnotations;

namespace WorkshopApplication.API.Dtos;

public class ParticipantDto
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public string Email { get; set; }
    
    [MaxLength(100)]
    public string PhoneNumber { get; set; }
}