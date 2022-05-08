using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Admin.User.Models;

public enum Role
{
    Admin = 0,
    Employee = 1,
    Client = 2
}
public class RegisterRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public Role Role { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
}