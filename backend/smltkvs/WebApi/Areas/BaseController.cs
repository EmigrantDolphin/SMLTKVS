using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.SharedModels;

namespace WebApi.Areas;

public abstract class BaseController : ControllerBase
{
    public Roles CurrentUserRole => Enum.Parse<Roles>(HttpContext.User.FindFirstValue(ClaimTypes.Role));
    public Guid CurrentUserCompanyId => new Guid(HttpContext.User.FindFirstValue("CompanyId"));
    public Guid CurrentUserId => new Guid(HttpContext.User.FindFirstValue("UserId"));
}
