using Laboratory.Application.Commands;
using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Entities.Company;
using Laboratory.Persistence;
using MediatR;

namespace Laboratory.Application.CommandHandlers;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Unit>
{
    private readonly ILaboratoryContext _context;

    public CreateCompanyCommandHandler(ILaboratoryContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company(
            request.Name,
            request.Address,
            request.CompanyCode,
            request.ConstructionSites?
                .Select(x => new ConstructionSite(x.Name, x.Address))
                .ToList()
        );

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}