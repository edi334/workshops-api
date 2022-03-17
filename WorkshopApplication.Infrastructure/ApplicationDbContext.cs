using Microsoft.EntityFrameworkCore;
using WorkshopApplication.Core;
using WorkshopApplication.Infrastructure.Configs;

namespace WorkshopApplication.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Workshop> Workshops { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationConfig());
        modelBuilder.ApplyConfiguration(new ParticipantConfig());
        modelBuilder.ApplyConfiguration(new WorkshopConfig());
    }
}