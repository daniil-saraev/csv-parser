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
    public async Task<ActionResult<CsvUploaded>> UploadCsv(IFormFile file, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new UploadCsv 
            { 
                File = file 
            }, cancellationToken);
        return Ok(response);
    }

    [HttpGet("results/execution/{from}/{to}")]
    public async Task<ActionResult<SelectedResults>> GetResultsByAverageExecutionTime(int from, int to, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetResultsByAverageExecutionTime 
            { 
                From = from, 
                To = to 
            }, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("results/indicator/{from}/{to}")]
    public async Task<ActionResult<SelectedResults>> GetResultsByAverageIndicator(float from, float to, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetResultsByAverageIndicator 
            { 
                From = from, 
                To = to 
            }, cancellationToken);
        return Ok(response);
    }

    [HttpGet("results/datetime/{from}/{until}")]
    public async Task<ActionResult<SelectedResults>> GetResultsByDateTime(DateTime from, DateTime until, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetResultsByDateTime 
            { 
                From = from, 
                Until = until
            }, cancellationToken);
        return Ok(response);
    }

    [HttpGet("results/{filename}")]
    public async Task<ActionResult<SelectedResults>> GetResultsByFileName(string fileName, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetResultsByFileName 
            { 
                FileName = fileName 
            }, cancellationToken);
        return Ok(response);
    }

    [HttpGet("values/{filename}")]
    public async Task<ActionResult<SelectedValues>> GetValuesByFileName(string fileName, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetValuesByFileName 
            { 
                FileName = fileName 
            }, cancellationToken);
        return Ok(response);
    }
}
