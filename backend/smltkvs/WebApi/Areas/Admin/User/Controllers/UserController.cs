using Authentication.Application.Commands.Users;
using Authentication.Application.Queries.Interfaces;
using Infrastructure.OneOf.Extensions;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.User.Models;

namespace WebApi.Areas.Admin.User.Controllers;

public class UserController : AdminControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IGetUsers _getUsers;

    public UserController(IMediator mediatr, IGetUsers getUsers)
    {
        _mediatr = mediatr;
        _getUsers = getUsers;
    }

    [HttpPost("api/auth/user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
    {
        try
        {
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
    
    [HttpGet("api/auth/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUsers([FromQuery] Role? role)
    {
        try
        {
            var users = await _getUsers.ExecuteAsync(role?.Adapt<global::Authentication.Domain.Enums.Role>());

            return Ok(users.Adapt<IList<UserResponse>>());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}