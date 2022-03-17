using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure.Configs;

public class WorkshopConfig : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id)
            .ValueGeneratedOnAdd();

        builder.Property(w => w.Name)
            .IsRequired()
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(w => w.Description)
            .IsRequired()
            .HasColumnType("longtext");

        builder.Property(w => w.Category)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10)
            .HasDefaultValue("");
    }
}