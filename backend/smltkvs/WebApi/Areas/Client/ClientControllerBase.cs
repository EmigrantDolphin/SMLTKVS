using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Client;

[ApiController]
[Authorize(Roles = "ClientAdmin, Client")]
[ApiExplorerSettings(GroupName = ApiAreas.Client)]
public class ClientControllerBase : BaseController { }
