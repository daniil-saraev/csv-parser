using CsvParser.Core.Exceptions;
using CsvParser.Core.Interfaces;

namespace CsvParser.Core.Services;

internal class ErrorLogService : IErrorLogService
{
    private int _errorCount;

    public int ErrorCount => _errorCount;

    public ErrorLogService()
    {
        _errorCount = 0;
    }

    public void LogParsingError(ValidationException exception)
    {
        _errorCount++;
    }
}