using Laboratory.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Persistence;

public interface ILaboratoryContext
{
    DbSet<ConcreteCubeStrengthTest> ConcreteCubeStrengthTests { get; set; }
    DbSet<Company> Companies { get; set; }
    Task<int> SaveChangesAsync();
}