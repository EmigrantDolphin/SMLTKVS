using Authentication.Application.Commands.Users;
using Authentication.Application.Queries.Interfaces;
using Authentication.Domain.Enums;
using Infrastructure.OneOf.Extensions;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.SharedModels;

namespace WebApi.Areas.Employee.Users;

public class UserController : EmployeeControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IGetUsers _getUsers;

    public UserController(IMediator mediatr, IGetUsers getUsers)
    {
        _mediatr = mediatr;
        _getUsers = getUsers;
    }

    [HttpPost("api/employee/user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
    {
        try
        {
            var allowedRoles = new List<Roles> { Roles.Client, Roles.ClientAdmin };
            if (!allowedRoles.Contains(request.Role))
            {
                return BadRequest("Darbuotojas gali kurti tik administratorius klientus ir klientus.");
            }
            
            var commandResponse = await _mediatr.Send(request.Adapt<RegisterUserCommand>());

            if (commandResponse.IsSuccess())
            {
                return Ok();
            }

            return BadRequest(commandResponse.AsError().Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("api/employee/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUsers([FromQuery] Roles? role)
    {
        try
        {
            var users = await _getUsers.ExecuteAsync(role?.Adapt<Role>(), null);

            return Ok(users.Adapt<IList<UserResponse>>());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}