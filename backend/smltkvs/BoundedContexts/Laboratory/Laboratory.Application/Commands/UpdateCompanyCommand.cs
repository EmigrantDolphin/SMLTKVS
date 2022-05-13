using Infrastructure.OneOf.Types;
using MediatR;
using OneOf;

namespace Laboratory.Application.Commands;

public record UpdateCompanyCommand(
    Guid CompanyId,
    string Name,
    string Address,
    string CompanyCode,
    List<UpdateConstructionSiteCommand>? ConstructionSites) : IRequest<OneOf<Success, BadRequest>>;

public record UpdateConstructionSiteCommand(Guid? ConstructionSiteId, string Name, string Address);
