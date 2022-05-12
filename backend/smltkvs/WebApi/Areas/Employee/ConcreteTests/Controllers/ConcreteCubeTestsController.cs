using Infrastructure.OneOf.Extensions;
using Laboratory.Application.Commands;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Employee.ConcreteTests.Models;

namespace WebApi.Areas.Employee.ConcreteTests.Controllers;

public class ConcreteCubeTestsController : EmployeeControllerBase
{
    private readonly IMediator _mediatr;

    public ConcreteCubeTestsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("api/concrete/cube/test")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateConcreteCubeTest([FromBody] ConcreteCubeTestRequest request)
    {
        try
        {
            var result = await _mediatr.Send(request.Adapt<CreateConcreteCubeTestCommand>());

            if (result.IsSuccess())
            {
                return Ok();
            }

            return BadRequest(result.AsError().Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}