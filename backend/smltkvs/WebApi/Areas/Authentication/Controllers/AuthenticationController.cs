using Authentication.Application.Commands.Users;
using Infrastructure.OneOf.Extensions;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Authentication.Models;

namespace WebApi.Areas.Authentication.Controllers;

[ApiController]
public class AuthenticationController : AuthenticationControllerBase
{
    private readonly IMediator _mediatr;

    public AuthenticationController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("api/auth/user/login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] LoginRequest request)
    {
        try
        {
            var commandResponse = await _mediatr.Send(request.Adapt<LoginUserCommand>());

            if (commandResponse.IsSuccess())
            {
                return Ok(commandResponse.AsSuccess().Value.Adapt<LoginResponse>());
            }

            return BadRequest(commandResponse.AsError().Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}