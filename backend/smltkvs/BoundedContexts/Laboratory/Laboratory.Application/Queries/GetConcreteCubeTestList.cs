using Laboratory.Application.Queries.Dtos;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Application.Queries;

public record GetConcreteCubeTestListQuery(Guid? CurrentCompanyId = null) : IRequest<List<ConcreteCubeTestInfoDto>>;

public class GetConcreteCubeTestListQueryHandler : IRequestHandler<GetConcreteCubeTestListQuery, List<ConcreteCubeTestInfoDto>>
{
    private readonly ILaboratoryContext _context;

    public GetConcreteCubeTestListQueryHandler(ILaboratoryContext context)
    {
        _context = context;
    }

    public async Task<List<ConcreteCubeTestInfoDto>> Handle(GetConcreteCubeTestListQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.ConcreteCubeStrengthTests.AsQueryable();

        if (request.CurrentCompanyId.HasValue)
        {
            query = query.Where(x => x.ClientCompanyId == request.CurrentCompanyId.Value);
        }
        
        return await query
            .Select(x => 
                new ConcreteCubeTestInfoDto(
                    x.ConcreteCubeStrengthTestId,
                    x.TestProtocolNumber,
                    x.ClientCompany.Name,
                    x.ClientCompany.ConstructionSites.First(y => y.ConstructionSiteId == x.ClientConstructionSiteId).Address,
                    x.TestType,
                    x.TestExecutionDate,
                    x.TestExecutedByUserId))
            .ToListAsync(cancellationToken);
    }
}
