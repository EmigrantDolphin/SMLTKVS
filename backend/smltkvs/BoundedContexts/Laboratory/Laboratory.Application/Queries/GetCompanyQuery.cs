using Laboratory.Domain.Aggregates;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Application.Queries;

public record GetCompanyQuery(Guid CompanyId) : IRequest<Company>;

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Company>
{
    private readonly ILaboratoryContext _context;

    public GetCompanyQueryHandler(ILaboratoryContext context)
    {
        _context = context;
    }

    public async Task<Company> Handle(GetCompanyQuery request, CancellationToken cancellationToken) =>
        await _context.Companies
            .Where(x => x.CompanyId == request.CompanyId)
            .Include(x => x.ConstructionSites)
            .SingleAsync(cancellationToken);
}