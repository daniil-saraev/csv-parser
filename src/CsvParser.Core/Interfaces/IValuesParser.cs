using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

internal interface IValuesParser
{
    ParsingResult ReadValuesFromCsv(Stream stream);
}