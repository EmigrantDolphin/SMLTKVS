using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Admin.User.Models;

public enum Role
{
    Admin = 0,
    Employee = 1,
    Client = 2
}
public record RegisterRequest(
    [Required] Guid CompanyId,
    [Required] string Username,
    [Required] string Password,
    [Required] Role Role,
    string? Email,
    string? Name);