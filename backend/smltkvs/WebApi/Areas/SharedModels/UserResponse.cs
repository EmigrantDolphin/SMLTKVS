namespace WebApi.Areas.SharedModels;

public record UserResponse(Guid UserId, Guid CompanyId, string Username, string Name, string Email, Roles Role);