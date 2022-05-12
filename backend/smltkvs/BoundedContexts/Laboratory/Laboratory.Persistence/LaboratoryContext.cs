using Laboratory.Domain.Aggregates;
using Laboratory.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Persistence;

public class LaboratoryContext : DbContext, ILaboratoryContext
{
    public DbSet<ConcreteCubeStrengthTest> ConcreteCubeStrengthTests { get; set; }
    
    public LaboratoryContext(DbContextOptions<LaboratoryContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConcreteCubeStrengthTestEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ConcreteCubeStrengthTestDataEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CrossSectionalDimensionsEntityConfiguration());
    }

    public async Task<int> SaveChangesAsync() =>
        await base.SaveChangesAsync();
}