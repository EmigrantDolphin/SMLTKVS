using Authentication.Domain.Aggregates;
using Authentication.Domain.Enums;

namespace Authentication.Application.Queries.Interfaces;

public interface IGetUsers
{
    Task<IList<User>> ExecuteAsync(Role? role);
}