using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Authentication.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = ApiAreas.Auth)]
public abstract class AuthenticationControllerBase : BaseController { }