namespace CsvParser.Core.Interfaces;

public interface ICsvService
{
    public Task<int> ProcessCsv(Stream stream, string fileName, CancellationToken cancellationToken = default);
}