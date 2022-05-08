using Authentication.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Persistence;

public interface IAuthenticationContext
{
    public DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync();
}