#pragma warning disable CS1573

using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CsvParser.Api.Requests;
using CsvParser.Api.Responses;

namespace CsvParser.Api.Controllers;

[ApiController]
[Route("csv")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ApiController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Processes .csv file and persists valid data.
    /// </summary>
    /// <param name="file">.csv file</param>
    /// <response code="200">Returns a response containing the number of errors 
    /// that occured during parsing due to invalid values or format.</response>
    /// <response code="400">File is empty, contains no valid records or has more records than allowed.</response>
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

    /// <summary>
    /// Returns results, average execution time of which falls within specified range.
    /// </summary>
    /// <param name="from">Lower bound of the range.</param>
    /// <param name="to">Upper bound of the range.</param>
    /// <response code="200">Returns results if any found, otherwise an empty collection.</response>
    /// <response code="400">Invalid input parameters.</response>
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

    /// <summary>
    /// Returns results, average indicator of which falls within specified range.
    /// </summary>
    /// <param name="from">Lower bound of the range.</param>
    /// <param name="to">Upper bound of the range.</param>
    /// <response code="200">Returns results if any found, otherwise an empty collection.</response>
    /// <response code="400">Invalid input parameters.</response>
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

    /// <summary>
    /// Returns results, operation's launch time of which falls within specified DateTime range.
    /// </summary>
    /// <param name="from">Lower bound of the range.</param>
    /// <param name="until">Upper bound of the range.</param>
    /// <response code="200">Returns results if any found, otherwise an empty collection.</response>
    /// <response code="400">Invalid input parameters.</response>
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

    /// <summary>
    /// Returns result by the specified file name.
    /// </summary>
    /// <param name="filename">A full name of the file. For example: myfile.csv</param>
    /// <response code="200">Returns a collection containing a single result if found, otherwise an empty collection.</response>
    /// <response code="400">Invalid input parameters.</response>
    [HttpGet("results/{filename}")]
    public async Task<ActionResult<SelectedResults>> GetResultsByFileName(string filename, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetResultsByFileName 
            { 
                FileName = filename 
            }, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Returns values by the specified file name.
    /// </summary>
    /// <param name="filename">A full name of the file. For example: myfile.csv</param>
    /// <response code="200">Returns values if any found, otherwise an empty collection.</response>
    /// <response code="400">Invalid input parameters.</response>
    [HttpGet("values/{filename}")]
    public async Task<ActionResult<SelectedValues>> GetValuesByFileName(string filename, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetValuesByFileName 
            { 
                FileName = filename 
            }, cancellationToken);
        return Ok(response);
    }
}

#pragma warning restore CS1573

