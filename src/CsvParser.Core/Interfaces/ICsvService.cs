using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

public interface ICsvService
{
    IEnumerable<Value> ReadValuesFromCsv(Stream stream);
}