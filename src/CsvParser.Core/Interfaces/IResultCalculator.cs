using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

/// <summary>
/// Encapsulates a <see cref="Result"/> creation logic.
/// </summary>
internal interface IResultCalculator
{
    /// <summary>
    /// Performs calculations on a collection of values.
    /// </summary>
    /// <param name="values">A collection of values to calculate the <see cref="Result"/> from.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>A single <see cref="Result"/> object that is linked to the values.</returns>
    Result ComputeResult(IEnumerable<Value> values, string fileName);
}