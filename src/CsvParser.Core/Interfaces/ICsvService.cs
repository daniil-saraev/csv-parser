namespace CsvParser.Core.Interfaces;

public interface ICsvService
{
    public Task ProcessCsv(Stream stream, string fileName, IErrorLogService logService, CancellationToken cancellationToken = default);
}