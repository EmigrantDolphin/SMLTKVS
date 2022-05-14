using Authentication.Application.Queries.Interfaces;
using Authentication.Domain.Enums;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.SharedModels;

namespace WebApi.Areas.Client.Users;

public class UsersController : ClientControllerBase
    {
        private readonly IGetUsers _getUsers;

        public UsersController(IGetUsers getUsers)
        {
            _getUsers = getUsers;
        }

        [HttpGet("api/client/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers([FromQuery] Roles? role)
        {
            try
            {
                var allowedRoles = new List<Roles> { Roles.Client, Roles.ClientAdmin };
                if (role.HasValue && allowedRoles.Contains(role.Value))
                {
                    return BadRequest("Galite peržiūrėti tik klientus ir klientus administratorius");
                }
                var users = await _getUsers.ExecuteAsync(role?.Adapt<Role>(), CurrentUserCompanyId);

                return Ok(users.Adapt<IList<UserResponse>>());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }