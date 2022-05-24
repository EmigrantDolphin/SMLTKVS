using Authentication.Domain.Aggregates;
using Authentication.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Application.Queries;

public record GetUserQuery(Guid UserId) : IRequest<User?>;

public class GetCompaniesQueryHandler : IRequestHandler<GetUserQuery, User?>
{
    private readonly IAuthenticationContext _context;

    public GetCompaniesQueryHandler(IAuthenticationContext context)
    {
        _context = context;
    }

    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        await _context.Users
            .FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);
}
