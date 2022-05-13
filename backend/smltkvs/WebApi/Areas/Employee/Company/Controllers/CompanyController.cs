using Infrastructure.OneOf.Extensions;
using Laboratory.Application.Commands;
using Laboratory.Application.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Employee.Company.Models;

namespace WebApi.Areas.Employee.Company.Controllers;

public class CompanyController : EmployeeControllerBase
{
    private readonly IMediator _mediatr;

    public CompanyController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("api/company")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        try
        {
            await _mediatr.Send(request.Adapt<CreateCompanyCommand>());
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("api/company/{companyId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCompany([FromRoute] Guid companyId, [FromBody] UpdateCompanyRequest request)
    {
        try
        {
            var result = await _mediatr.Send(request.Adapt<UpdateCompanyCommand>() with {CompanyId = companyId});
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

    [HttpGet("api/companies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompanies()
    {
        try
        {
            var companies = await _mediatr.Send(new GetCompaniesQuery());
            var result = companies.Adapt<List<GetCompaniesResponse>>();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}