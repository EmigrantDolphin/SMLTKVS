using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Application.Queries;

public record GetConcreteCubeTestStrengthsQuery(Guid ConstructionSiteId) : IRequest<decimal[]>;

public class GetConcreteCubeTestStrengthsQueryHandler : IRequestHandler<GetConcreteCubeTestStrengthsQuery, decimal[]> 
{
    private readonly ILaboratoryContext _context;

    public GetConcreteCubeTestStrengthsQueryHandler(ILaboratoryContext context)
    {
        _context = context;
    }

    public async Task<decimal[]> Handle(GetConcreteCubeTestStrengthsQuery request,
        CancellationToken cancellationToken)
    {
        var newestStrengths = new List<decimal>();
        var newestTests = await _context.ConcreteCubeStrengthTests
            .AsNoTracking()
            .Include(x => x.TestData)
            .Where(x => x.ClientConstructionSiteId == request.ConstructionSiteId)
            .OrderByDescending(x => x.TestExecutionDate)
            .Take(35)
            .ToListAsync(cancellationToken);

        foreach (var test in newestTests)
        {
            foreach (var testData in test.TestData)
            {
                if (newestStrengths.Count < 34)
                {
                    newestStrengths.Add(testData.CrushingStrength);
                }
                else
                {
                    return newestStrengths.ToArray();
                }
            }
        }

        return Array.Empty<decimal>();
    }
}