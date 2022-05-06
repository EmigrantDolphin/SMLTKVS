using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Authentication.Models;

public record LoginRequest
{
    [Required]
    public Guid UserId { get; init; }

    [Required]
    public string Password { get; init; }
}