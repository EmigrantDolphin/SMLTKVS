using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Admin;

[ApiController]
[Authorize(Roles = "Admin")]
[ApiExplorerSettings(GroupName = ApiAreas.Admin)]
public abstract class AdminControllerBase : ControllerBase { }
