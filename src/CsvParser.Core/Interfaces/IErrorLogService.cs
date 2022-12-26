using CsvParser.Core.Exceptions;

namespace CsvParser.Core.Interfaces;

public interface IErrorLogService
{
    void LogParsingError(ValidationException exception);

    int ErrorCount { get; }
}
