namespace Authentication.Application.Commands.Users.ResponseDtos;

public record LoggedInUserDto(Guid UserId, string Username, string Token);