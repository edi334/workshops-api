using System.ComponentModel.DataAnnotations;

namespace WorkshopApplication.API.Dtos;

public class WorkshopDto
{
    public string? Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [MaxLength(10)]
    public string Category { get; set; }
}