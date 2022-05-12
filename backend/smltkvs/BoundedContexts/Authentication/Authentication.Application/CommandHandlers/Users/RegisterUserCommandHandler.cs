using Authentication.Application.Commands.Users;
using Authentication.Domain.Aggregates;
using Authentication.Domain.Enums;
using Authentication.Persistence;
using Infrastructure.OneOf.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace Authentication.Application.CommandHandlers.Users;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OneOf<Success, BadRequest>>
{
    private readonly IAuthenticationContext _context;

    public RegisterUserCommandHandler(IAuthenticationContext context)
    {
        _context = context;
    }
    
    public async Task<OneOf<Success, BadRequest>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var usernameExists = await _context.Users.AnyAsync(x => x.Username.Equals(request.Username), cancellationToken);
        if (usernameExists)
        {
            return new BadRequest("Username already exists");
        }
        
        var user = new User(request.Username, request.Password, Role.Client, request.Email, request.Name);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new Success();
    }
}