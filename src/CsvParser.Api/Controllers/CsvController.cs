using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CsvParser.Api.Requests;
using CsvParser.Api.Responses;

namespace CsvParser.Api.Controllers;

[ApiController]
[Route("api")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CsvController : ControllerBase
{
    private readonly IMediator _mediator;

    public CsvController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CsvUploaded>> UploadCsv(IFormFile file)
    {
        var response = await _mediator.Send(new UploadCsv { File = file });
        return Ok(response);
    }

    [HttpGet("results/execution")]
    public async Task<ActionResult<SelectedResults>> GetResultsByAverageExecutionTime([FromBody]GetResultsByAverageExecutionTime request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpGet("results/indicator")]
    public async Task<ActionResult<SelectedResults>> GetResultsByAverageIndicator([FromBody]GetResultsByAverageIndicator request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("results/datetime")]
    public async Task<ActionResult<SelectedResults>> GetResultsByDateTime([FromBody]GetResultsByDateTime request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("results/filename")]
    public async Task<ActionResult<SelectedResults>> GetResultsByFileName([FromBody]GetResultsByFileName request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("values/filename")]
    public async Task<ActionResult<SelectedValues>> GetValuesByFileName([FromBody]GetValuesByFileName request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
