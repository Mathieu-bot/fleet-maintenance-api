using FleetMaintenance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetMaintenance.Infrastructure.Persistence.Configurations;

public sealed class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    private const int StatusMaxLength = 30;

    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.ToTable("equipment");

        builder.HasKey(equipment => equipment.Id);
        builder.Property(equipment => equipment.Id).ValueGeneratedNever();

        builder.Property(equipment => equipment.Name).IsRequired().HasMaxLength(Equipment.NameMaxLength);
        builder.Property(equipment => equipment.SerialNumber).IsRequired().HasMaxLength(Equipment.SerialNumberMaxLength);
        builder.Property(equipment => equipment.Category).IsRequired().HasMaxLength(Equipment.CategoryMaxLength);
        builder.Property(equipment => equipment.Status).HasConversion<string>().HasMaxLength(StatusMaxLength);
        builder.Property(equipment => equipment.CreatedAt);

        builder.HasIndex(equipment => equipment.SerialNumber).IsUnique();
    }
}
