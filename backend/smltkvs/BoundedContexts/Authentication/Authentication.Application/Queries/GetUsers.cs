using Authentication.Application.Queries.Interfaces;
using Authentication.Domain.Aggregates;
using Authentication.Domain.Enums;
using Authentication.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Application.Queries;

public class GetUsers : IGetUsers
{
    private readonly IAuthenticationContext _context;

    public GetUsers(IAuthenticationContext context)
    {
        _context = context;
    }

    public async Task<IList<User>> ExecuteAsync(Role? role)
    {
        if (role.HasValue)
        {
            return await _context.Users.Where(x => x.Role == role).ToListAsync();
        }

        return await _context.Users.ToListAsync();
    }
}