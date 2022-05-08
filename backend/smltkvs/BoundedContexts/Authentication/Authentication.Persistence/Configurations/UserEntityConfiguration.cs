using Authentication.Domain.Aggregates;
using Authentication.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId).ValueGeneratedNever();
        builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(256).IsRequired(false);
        builder.Property(u => u.Name).HasMaxLength(256).IsRequired(false);
        builder.Property(u => u.Role).HasConversion(
            v => v.ToString(),
            v => (Role)Enum.Parse(typeof(Role), v))
            .HasMaxLength(50)
            .IsRequired();
    }
}