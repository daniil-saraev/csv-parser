namespace CsvParser.Core.Interfaces;

public interface IErrorLogService
{
    void LogError(string message, params object[] args);

    IEnumerable<string> Errors { get; }
}
