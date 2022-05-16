using Laboratory.Domain.Aggregates;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Application.Queries;

public record GetConcreteCubeTestQuery(Guid ConcreteCubeTestId) : IRequest<ConcreteCubeStrengthTest?>;

public class GetConcreteCubeTestQueryHandler : IRequestHandler<GetConcreteCubeTestQuery, ConcreteCubeStrengthTest?>
{
    private readonly ILaboratoryContext _context;

    public GetConcreteCubeTestQueryHandler(ILaboratoryContext context)
    {
        _context = context;
    }

    public async Task<ConcreteCubeStrengthTest?> Handle(GetConcreteCubeTestQuery request, CancellationToken cancellationToken) =>
        await _context.ConcreteCubeStrengthTests
            .Include(x => x.ClientCompany)
                .ThenInclude(x => x.ConstructionSites)  
            .Include(x => x.TestData)
                .ThenInclude(x => x.Dimensions)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.ConcreteCubeStrengthTestId == request.ConcreteCubeTestId, cancellationToken);
            
}
