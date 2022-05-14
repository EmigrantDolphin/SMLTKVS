using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Employee;

[ApiController]
[Authorize(Roles = "Admin, Employee")]
[ApiExplorerSettings(GroupName = ApiAreas.Employee)]
public abstract class EmployeeControllerBase : BaseController { }
