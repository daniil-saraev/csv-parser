using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

public interface IResultService
{
    Result ComputeResult(IEnumerable<Value> values, string fileName);
}