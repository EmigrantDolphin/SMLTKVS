using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Employee.Company.Models;

public record CreateCompanyRequest(
    [Required] string Name,
    [Required] string Address,
    [Required] string CompanyCode,
    List<ConstructionSiteRequest>? ConstructionSites);

public record ConstructionSiteRequest([Required]string Name, [Required]string Address);
