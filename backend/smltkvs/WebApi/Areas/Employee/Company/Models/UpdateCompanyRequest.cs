using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Employee.Company.Models;

public record UpdateCompanyRequest(
    [Required] string Name,
    [Required] string Address,
    [Required] string CompanyCode,
    List<UpdateConstructionSiteRequest>? ConstructionSites);

public record UpdateConstructionSiteRequest(Guid? ConstructionSiteId, [Required]string Name, [Required]string Address);
