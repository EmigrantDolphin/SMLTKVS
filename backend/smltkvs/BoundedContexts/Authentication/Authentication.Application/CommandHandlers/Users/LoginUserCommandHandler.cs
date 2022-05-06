using Authentication.Application.Commands.Users;
using Authentication.Application.Commands.Users.ResponseDtos;
using Authentication.Domain.Aggregates;
using Authentication.Persistence;
using Infrastructure.OneOf.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace Authentication.Application.CommandHandlers.Users;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, OneOf<Success<LoggedInUserDto>, BadRequest>>
{
    private readonly IAuthenticationContext _authContext;
    private readonly IMediator _mediator;

    public LoginUserCommandHandler(IAuthenticationContext authContext, IMediator mediator)
    {
        _mediator = mediator;
        _authContext = authContext;
    }

    public async Task<OneOf<Success<LoggedInUserDto>, BadRequest>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = await GetUser(command.UserId, command.Password);
        if (user == null)
        {
            return new BadRequest("Neteisingas prisijungimo vardas arba slaptažodis");
        }

        var newTokenResponse = await _mediator.Send(new GenerateTokenCommand(user.UserId, user.Username), cancellationToken);

        return new Success<LoggedInUserDto>(new LoggedInUserDto(user.UserId, user.Username, newTokenResponse.Token));
    }

    private async Task<User?> GetUser(Guid userId, string password) =>
        await _authContext.Users
            .Where(x => x.UserId == userId)
            .Where(x => x.Password == password)
            .FirstOrDefaultAsync();
}
