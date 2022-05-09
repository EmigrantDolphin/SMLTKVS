namespace WebApi.Areas.Admin.User.Models;

public record UserResponse(Guid UserId, string Username, string Name, string Email, Role Role);