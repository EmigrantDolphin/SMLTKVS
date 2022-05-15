namespace WebApi.Areas.Employee.Company.Models;

public record GetCompaniesResponse(
    Guid CompanyId,
    string Name,
    string Address,
    string CompanyCode,
    List<ConstructionSiteResponse>? ConstructionSites);

public record ConstructionSiteResponse(Guid ConstructionSiteId, string Name, string Address);