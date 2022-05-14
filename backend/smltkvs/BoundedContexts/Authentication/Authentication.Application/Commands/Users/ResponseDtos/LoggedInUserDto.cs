using Authentication.Domain.Enums;

namespace Authentication.Application.Commands.Users.ResponseDtos;

public record LoggedInUserDto(Guid UserId, Guid CompanyId, string Username, string Token, Role Role);