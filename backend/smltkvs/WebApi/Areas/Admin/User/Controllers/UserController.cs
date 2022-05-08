using Authentication.Application.Commands.Users;
using Infrastructure.OneOf.Extensions;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.User.Models;

namespace WebApi.Areas.Admin.User.Controllers;

public class UserController : AdminControllerBase
{
    private readonly IMediator _mediatr;

    public UserController(IMediator mediatr)
    {
        _mediatr = mediatr;
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
}