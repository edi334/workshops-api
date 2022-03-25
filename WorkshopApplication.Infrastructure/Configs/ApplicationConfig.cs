using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure.Configs;

public class ApplicationConfig : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .HasColumnType("varchar")
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Country)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(a => a.University)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(a => a.FieldOfStudy)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(20);

        builder.Property(a => a.Reason)
            .IsRequired()
            .HasColumnType("longtext");

        builder
            .HasOne(a => a.Workshop)
            .WithMany(w => w.Applications);
    }
}