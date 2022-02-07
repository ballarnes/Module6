using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class SpecificationEntityTypeConfiguration
    : IEntityTypeConfiguration<Specification>
{
    public void Configure(EntityTypeBuilder<Specification> builder)
    {
        builder.ToTable("Specification");

        builder.Property(ci => ci.Id)
            .UseHiLo("specification_hilo")
            .IsRequired();

        builder.Property(ci => ci.Socket)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(ci => ci.NumberOfCores)
            .IsRequired(true);

        builder.Property(ci => ci.NumberOfThreads)
            .IsRequired(true);

        builder.Property(ci => ci.ClockFrequency)
            .IsRequired(true);

        builder.Property(ci => ci.MaximumClockFrequency)
            .IsRequired(true);

        builder.Property(ci => ci.MemoryType)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(ci => ci.VideoLink)
            .IsRequired(false);
    }
}