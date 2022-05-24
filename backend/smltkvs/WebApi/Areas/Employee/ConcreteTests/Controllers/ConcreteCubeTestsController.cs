using Authentication.Application.Queries;
using Authentication.Application.Queries.Interfaces;
using Infrastructure.HttpClientFactories;
using Infrastructure.OneOf.Extensions;
using Laboratory.Application.Commands;
using Laboratory.Application.ProtocolTemplates;
using Laboratory.Application.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Employee.ConcreteTests.Models;
using WebApi.Areas.SharedModels;

namespace WebApi.Areas.Employee.ConcreteTests.Controllers;

public class ConcreteCubeTestsController : EmployeeControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IGetUsers _getUsers;
    private readonly ILatexCompilerService _latexCompilerService;

    public ConcreteCubeTestsController(IMediator mediatr, IGetUsers getUsers, ILatexCompilerService latexCompilerService)
    {
        _mediatr = mediatr;
        _getUsers = getUsers;
        _latexCompilerService = latexCompilerService;
    }

    [HttpPost("api/employee/concrete/cube/test")]
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
    
    [HttpGet("api/employee/concrete/cube/tests")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetConcreteCubeTests()
    {
        try
        {
            var result = await _mediatr.Send(new GetConcreteCubeTestListQuery());
            var users = await _getUsers.ExecuteAsync(result.Select(x => x.ExecutingUserId).ToArray());

            var response = result.Select(x =>
                new ConcreteCubeTestsInfoResponse(
                    x.ConcreteCubeTestId,
                    x.ProtocolNumber,
                    x.CompanyName,
                    x.ConstructionSiteAddress,
                    x.TestType.Adapt<TestType>(),
                    x.TestExecutionDate,
                    users.Single(y => y.UserId == x.ExecutingUserId).Name));

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("api/employee/concrete/cube/tests/{testId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetConcreteCubeTest([FromRoute] Guid testId)
    {
        try
        {
            var result = await _mediatr.Send(new GetConcreteCubeTestQuery(testId));
            if (result is null)
            {
                return BadRequest("Neegzistuoja");
            }

            var executingUser = await _mediatr.Send(new GetUserQuery(result.TestExecutedByUserId));

            var response = ConcreteCubeTestResponse.ToModel(result, executingUser?.Name);
            
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("api/employee/concrete/cube/tests/{testId}/protocol")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetConcreteCubeTestProtocol([FromRoute] Guid testId)
    {
        try
        {
            var test = await _mediatr.Send(new GetConcreteCubeTestQuery(testId));
            if (test is null)
            {
                return BadRequest("Neegzistuoja");
            }
            var executingUser = await _mediatr.Send(new GetUserQuery(test.TestExecutedByUserId));
            var executingUserCompany = await _mediatr.Send(new GetCompanyQuery(executingUser!.CompanyId));

            var latexFile = ConcreteCubeProtocol.GetFile(test, executingUserCompany, executingUser!.Name);
            var latexBytes = await _latexCompilerService.GetCompiledLatexPdf(latexFile);


            HttpContext.Response.Headers.ContentDisposition = "inline;filename=protocol.pdf";
            return File(latexBytes, "application/pdf", "protocol.pdf");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}