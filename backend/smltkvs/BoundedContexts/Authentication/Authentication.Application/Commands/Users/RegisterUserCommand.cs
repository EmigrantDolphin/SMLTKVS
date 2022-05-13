using Authentication.Domain.Enums;
using Infrastructure.OneOf.Types;
using OneOf;
using MediatR;

namespace Authentication.Application.Commands.Users;

public record RegisterUserCommand(Guid CompanyId, string Username, string Password, string Email, string Name, Role Role)
    :IRequest<OneOf<Success, BadRequest>>;