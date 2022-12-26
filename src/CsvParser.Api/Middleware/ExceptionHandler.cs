using System.Net;
using System.Net.Mime;
using CsvParser.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CsvParser.Api.Middleware;

internal class ExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, null);
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        switch (exception)
        {
            case ValidationException:
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var badResult = new BadRequestObjectResult(exception.Message);
                return context.Response.WriteAsJsonAsync(badResult);
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.StartAsync();
        }     
    }
}