using Authentication.Application.Commands.Users;
using Infrastructure.OneOf.Extensions;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.SharedModels;

namespace WebApi.Areas.ClientAdmin.Users;

public class UserController : ClientAdminControllerBase
{
   private readonly IMediator _mediatr;

   public UserController(IMediator mediatr)
   {
       _mediatr = mediatr;
   }

   [HttpPost("api/client-admin/user")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
   {
       try
       {
           var allowedRoles = new List<Roles> { Roles.ClientAdmin, Roles.Client };
           if (!allowedRoles.Contains(request.Role))
           {
               return BadRequest("Galite kurti tik klientus ir klientus adminus");
           }
           
           request = request with { CompanyId = CurrentUserCompanyId };
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