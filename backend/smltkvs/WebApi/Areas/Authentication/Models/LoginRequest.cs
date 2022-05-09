using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Authentication.Models;

public record LoginRequest
{
    [Required]
    public string Username { get; init; }

    [Required]
    public string Password { get; init; }
}