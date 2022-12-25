using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

internal interface IValuesParser
{
    IEnumerable<Value> ReadValuesFromCsv(Stream stream, string fileName, IErrorLogService logService);
}