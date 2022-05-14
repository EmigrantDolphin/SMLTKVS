namespace WebApi.Areas.SharedModels;

public record UserResponse(Guid UserId, string Username, string Name, string Email, Roles Role);