using System.Net;
using CsvParser.Core.Exceptions;

namespace CsvParser.Api.Middleware;

internal class ExceptionHandler
{
    private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            string result;
            switch(exception)
            {
                case ValidationException:
                    code = HttpStatusCode.BadRequest;
                    result = exception.Message;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    result = exception.Message;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
}