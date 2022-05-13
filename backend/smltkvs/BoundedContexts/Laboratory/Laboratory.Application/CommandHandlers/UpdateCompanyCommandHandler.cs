using Infrastructure.OneOf.Types;
using Laboratory.Application.Commands;
using Laboratory.Domain.Entities.Company;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace Laboratory.Application.CommandHandlers;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, OneOf<Success, BadRequest>>
{
    private readonly ILaboratoryContext _context;

    public UpdateCompanyCommandHandler(ILaboratoryContext context)
    {
        _context = context;
    }
    
    public async Task<OneOf<Success, BadRequest>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyId == request.CompanyId, cancellationToken);
        if (company is null)
        {
            return new BadRequest("Įmonė nerasta");
        }

        company.Update(
            request.Name,
            request.Address,
            request.CompanyCode);

        request.ConstructionSites?
            .Where(x => x.ConstructionSiteId is not null)
            .ToList()
            .ForEach(x => 
                company.UpdateConstructionSite(x.ConstructionSiteId!.Value, x.Name, x.Address)
            );
        
        request.ConstructionSites?
            .Where(x => x.ConstructionSiteId is null)
            .ToList()
            .ForEach(x =>
                company.AddConstructionSite(x.Name, x.Address)
            );
        
        
        await _context.SaveChangesAsync();
        
        return new Success();
    }
}