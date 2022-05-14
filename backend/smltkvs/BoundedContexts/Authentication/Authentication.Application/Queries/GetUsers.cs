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

    public async Task<IList<User>> ExecuteAsync(Role? role, Guid? companyId)
    {
        var usersQuery = _context.Users.AsQueryable();
        if (role.HasValue)
        {
            usersQuery = usersQuery.Where(x => x.Role == role);
        }

        if (companyId.HasValue)
        {
            usersQuery = usersQuery.Where(x => x.CompanyId == companyId);
        }

        return await usersQuery.ToListAsync();
    }
}