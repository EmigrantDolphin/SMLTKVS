using Authentication.Application.Commands.Users.ResponseDtos;
using Authentication.Domain.Enums;
using MediatR;

namespace Authentication.Application.Commands.Users;

public record GenerateTokenCommand(Guid UserId, Guid CompanyId, string Username, Role Role) : IRequest<GeneratedTokenDto>;