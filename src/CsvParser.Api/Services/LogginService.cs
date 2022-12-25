using CsvParser.Core.Interfaces;

namespace CsvParser.Api.Services;

internal class ErrorLogService : IErrorLogService
{
    private readonly List<string> _errors;

    public IEnumerable<string> Errors => _errors;

    public ErrorLogService()
    {
        _errors = new List<string>();
    }

    public void LogError(string message, params object[] args)
    {
        _errors.Add(message + ";" + args.ToString());
    }
}