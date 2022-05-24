using MediatR;

namespace Authentication.Application.Commands.Users;

public record ChangePasswordCommand(string NewPassword, Guid UserId) : IRequest<Unit>;