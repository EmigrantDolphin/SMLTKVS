namespace WebApi.Areas.Authentication.Models;

public record LoginResponse(Guid UserId, Guid CompanyId, string Username, string Token);