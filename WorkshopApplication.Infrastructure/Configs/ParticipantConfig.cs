using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure.Configs;

public class ParticipantConfig : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(p => p.Email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .HasDefaultValue("");
        
        builder.Property(p => p.PhoneNumber)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .HasDefaultValue("");

        builder
            .HasOne(p => p.Application)
            .WithOne(a => a.Participant)
            .HasForeignKey<Application>(a => a.ParticipantId);
    }
}