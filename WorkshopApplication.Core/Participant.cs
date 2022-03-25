namespace WorkshopApplication.Core;

public class Participant : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Application Application { get; set; }
}