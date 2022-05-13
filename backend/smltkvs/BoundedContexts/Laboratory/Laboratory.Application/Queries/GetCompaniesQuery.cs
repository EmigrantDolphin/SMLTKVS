using Laboratory.Domain.Aggregates;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Application.Queries;

public class GetCompaniesQuery: IRequest<List<Company>> { }

public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, List<Company>>
{
    private readonly ILaboratoryContext _context;

    public GetCompaniesQueryHandler(ILaboratoryContext context)
    {
        _context = context;
    }

    public async Task<List<Company>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken) =>
        await _context.Companies
            .Include(x => x.ConstructionSites)
            .ToListAsync(cancellationToken);
}