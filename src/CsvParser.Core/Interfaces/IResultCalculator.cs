using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

internal interface IResultCalculator
{
    Result ComputeResult(IEnumerable<Value> values, string fileName);
}