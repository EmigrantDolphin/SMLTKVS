using Laboratory.Domain.Entities.ConcreteCube;
using Laboratory.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.Persistence.Configurations;

public class CrossSectionalDimensionsEntityConfiguration : IEntityTypeConfiguration<CrossSectionalDimensions>
{
    public void Configure(EntityTypeBuilder<CrossSectionalDimensions> builder)
    {
        builder.ToTable("CrossSectionalDimensions", Schemas.ConcreteCube);
        builder.HasKey(x => x.CrossSectionalDimensionsId);
        builder.Property(x => x.CrossSectionalDimensionsId).ValueGeneratedNever();

        builder.Property(x => x.Dimension).HasConversion(
            v => v.ToString(),
            v => (CubeDimension)Enum.Parse(typeof(CubeDimension), v))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Value).HasPrecision(15,5).IsRequired();
    }
}