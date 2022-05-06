namespace WebApi.Areas.Authentication.Models;

public record LoginResponse(Guid UserId, string Username, string Token);