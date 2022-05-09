using Authentication.Application.Commands.Users.ResponseDtos;
using Infrastructure.OneOf.Types;
using OneOf;
using MediatR;

namespace Authentication.Application.Commands.Users;

public record LoginUserCommand(string Username, string Password) : IRequest<OneOf<Success<LoggedInUserDto>, BadRequest>>;