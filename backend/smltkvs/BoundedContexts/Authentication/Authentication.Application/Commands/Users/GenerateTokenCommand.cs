using Authentication.Application.Commands.Users.ResponseDtos;
using MediatR;

namespace Authentication.Application.Commands.Users;

public record GenerateTokenCommand(Guid UserId, string Username) : IRequest<GeneratedTokenDto>;