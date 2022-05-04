using Authentication.Domain.Aggregates;
using Authentication.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Persistence;

public class AuthenticationContext : DbContext, IAuthenticationContext
{
    public DbSet<User> Users { get; set; }

    public AuthenticationContext(DbContextOptions<AuthenticationContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}