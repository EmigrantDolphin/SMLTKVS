using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.SharedModels;

namespace WebApi.Areas;

public abstract class BaseController : ControllerBase
{
    public Roles CurrentUserRole { get; }
    public Guid CurrentUserCompanyId { get; }

    public BaseController()
    {
        CurrentUserRole = Enum.Parse<Roles>(HttpContext.User.FindFirstValue(ClaimTypes.Role));
        CurrentUserCompanyId = new Guid(HttpContext.User.FindFirstValue("CompanyId"));
    }
}
