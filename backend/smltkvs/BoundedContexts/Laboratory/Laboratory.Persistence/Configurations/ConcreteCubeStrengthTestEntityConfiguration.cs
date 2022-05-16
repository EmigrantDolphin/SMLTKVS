using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.Persistence.Configurations;

public class ConcreteCubeStrengthTestEntityConfiguration : IEntityTypeConfiguration<ConcreteCubeStrengthTest>
{
    public void Configure(EntityTypeBuilder<ConcreteCubeStrengthTest> builder)
    {
        builder.ToTable("StrengthTest", Schemas.ConcreteCube);
        builder.HasKey(u => u.ConcreteCubeStrengthTestId);
        builder.Property(u => u.ConcreteCubeStrengthTestId).ValueGeneratedNever();
        builder.Property(u => u.TestProtocolNumber).HasMaxLength(50).IsRequired();
        builder.Property(u => u.ClientCompanyId).IsRequired();
        builder
            .HasOne(u => u.ClientCompany)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(u => u.ClientConstructionSiteId).IsRequired();
        builder.Property(u => u.EmployeeCompanyId).IsRequired();
        builder.Property(u => u.TestExecutionDate).IsRequired();
        builder.Property(u => u.TestSamplesReceivedDate).IsRequired();
        builder.Property(u => u.TestSamplesDeliveredBy).HasMaxLength(256).IsRequired();
        builder.Property(u => u.TestSamplesReceivedComment).HasMaxLength(2000).IsRequired();
        builder.Property(u => u.TestSamplesReceivedCount).IsRequired();
        builder.Property(u => u.TestExecutedByUserId).IsRequired();
        builder.Property(u => u.ProtocolCreatedByUserId).IsRequired();
        builder.Property(u => u.TestType).HasConversion(
            v => v.ToString(),
            v => (TestType)Enum.Parse(typeof(TestType), v))
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(u => u.ConcreteType).HasConversion(
            v => v.ToString(),
            v => (ConcreteType)Enum.Parse(typeof(ConcreteType), v))
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(u => u.AcceptedSampleCount).IsRequired();
        builder.Property(u => u.RejectedSampleCount).IsRequired();
        builder.Property(u => u.AverageCrushForce).HasPrecision(15,5).IsRequired();
        builder.Property(u => u.StandardUncertainty).HasPrecision(15,5).IsRequired();
        builder.Property(u => u.ExtendedUncertainty).HasPrecision(15,5).IsRequired();
        builder.Property(u => u.StandardDeviation).HasPrecision(15,5).IsRequired();
        builder.Property(u => u.CharacteristicStrength).HasPrecision(15,5).IsRequired();
        builder.Property(u => u.ConcreteRating).HasMaxLength(100).IsRequired();

        builder.HasMany(u => u.TestData)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
    }
}