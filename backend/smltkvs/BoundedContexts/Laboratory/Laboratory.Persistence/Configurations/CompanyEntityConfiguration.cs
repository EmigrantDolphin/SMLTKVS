using Laboratory.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.Persistence.Configurations;

public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.CompanyId);
        builder.Property(x => x.CompanyId).ValueGeneratedNever();

        builder.Property(x => x.Name).HasMaxLength(256);
        builder.Property(x => x.Address).HasMaxLength(256);
        builder.Property(x => x.CompanyCode).HasMaxLength(20);

        builder.HasMany(x => x.ConstructionSites)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
    }
}