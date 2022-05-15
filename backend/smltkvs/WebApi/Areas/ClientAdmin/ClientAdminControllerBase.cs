using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.ClientAdmin;

[ApiController]
[Authorize(Roles = "ClientAdmin")]
[ApiExplorerSettings(GroupName = ApiAreas.ClientAdmin)]
public class ClientAdminControllerBase : BaseController { }
