using Microsoft.EntityFrameworkCore;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Workshop> Workshops { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
}