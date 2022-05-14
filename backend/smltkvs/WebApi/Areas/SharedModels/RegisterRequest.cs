using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.SharedModels;

public record RegisterRequest(
    [Required] Guid CompanyId,
    [Required] string Username,
    [Required] string Password,
    [Required] Roles Role,
    string? Email,
    string? Name);