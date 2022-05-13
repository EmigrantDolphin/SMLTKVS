using MediatR;

namespace Laboratory.Application.Commands;

public record CreateCompanyCommand (
    string Name,
    string Address,
    string CompanyCode,
    List<CreateCompanyCommandConstructionSite> ConstructionSites) : IRequest<Unit>;

public record CreateCompanyCommandConstructionSite(string Name, string Address);