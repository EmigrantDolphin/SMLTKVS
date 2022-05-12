using Laboratory.Domain.Entities.ConcreteCube;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.Persistence.Configurations;

public class ConcreteCubeStrengthTestDataEntityConfiguration : IEntityTypeConfiguration<ConcreteCubeStrengthTestData>
{
    public void Configure(EntityTypeBuilder<ConcreteCubeStrengthTestData> builder)
    {
        builder.ToTable("StrengthTestData", Schemas.ConcreteCube);
        builder.HasKey(x => x.ConcreteCubeStrengthTestDataId);
        builder.Property(x => x.ConcreteCubeStrengthTestDataId).ValueGeneratedNever();

        builder.Property(x => x.Comment).HasMaxLength(2000).IsRequired(false);
        builder.Property(x => x.DestructivePower).HasPrecision(15,5).IsRequired();
        builder.Property(x => x.CrushingStrength).HasPrecision(15,5).IsRequired();

        builder.HasMany(x => x.Dimensions)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
    }
}