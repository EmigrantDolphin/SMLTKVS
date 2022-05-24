using Authentication.Application.Commands.Users;
using Authentication.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Application.CommandHandlers.Users;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
{
    private readonly IAuthenticationContext _context;

    public ChangePasswordCommandHandler(IAuthenticationContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleAsync(x => x.UserId == request.UserId, cancellationToken);

        user.UpdatePassword(request.NewPassword);

        await _context.SaveChangesAsync();
        
        return Unit.Value;
    }
}