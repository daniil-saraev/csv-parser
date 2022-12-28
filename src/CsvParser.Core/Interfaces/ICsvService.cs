using CsvParser.Core.Exceptions;

namespace CsvParser.Core.Interfaces;

/// <summary>
/// A service that encapsulates top level business logic.
/// </summary>
public interface ICsvService
{
    /// <summary>
    /// Parses values and computes a result, persists data.
    /// </summary>
    /// <param name="stream">A stream to read from.</param>
    /// <param name="fileName">Name of the file</param>
    /// <returns>Number of errors that occured during parsing.</returns>
    /// <exception cref="ValidationException"></exception>
    public Task<int> ProcessCsv(Stream stream, string fileName, CancellationToken cancellationToken = default);
}