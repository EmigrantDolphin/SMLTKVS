using Laboratory.Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.Persistence.Configurations;

public class ConstructionSiteEntityConfiguration : IEntityTypeConfiguration<ConstructionSite>
{
    public void Configure(EntityTypeBuilder<ConstructionSite> builder)
    {
        builder.HasKey(x => x.ConstructionSiteId);
        builder.Property(x => x.ConstructionSiteId).ValueGeneratedNever();

        builder.Property(x => x.Name).HasMaxLength(256);
        builder.Property(x => x.Address).HasMaxLength(256);
    }
}