using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Admin;

[ApiController]
// [Authorize("Admin")]
[AllowAnonymous]
[ApiExplorerSettings(GroupName = ApiAreas.Auth)]
public abstract class AdminControllerBase : ControllerBase { }
