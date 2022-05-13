namespace Authentication.Application.Commands.Users.ResponseDtos;

public record LoggedInUserDto(Guid UserId, Guid CompanyId, string Username, string Token);