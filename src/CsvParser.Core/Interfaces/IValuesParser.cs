using CsvParser.Core.Models;
using CsvParser.Core.Exceptions;

namespace CsvParser.Core.Interfaces;

/// <summary>
/// Encapsulates parsing logic.
/// </summary>
internal interface IValuesParser
{
    /// <summary>
    /// Parses records in csv file, validates and creates <see cref="Value"/> entities.
    /// </summary>
    /// <param name="stream">A stream to read from.</param>
    /// <returns>A <see cref="ParsingResult"/> that contains a collection of values and the number of parsing errors.</returns>
    /// <exception cref="ValidationException"></exception>
    ParsingResult ReadValuesFromCsv(Stream stream);
}