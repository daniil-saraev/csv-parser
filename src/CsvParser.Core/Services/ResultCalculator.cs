using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using MathNet.Numerics.Statistics;
using System.Collections.Immutable;

namespace CsvParser.Core.Services;

internal class ResultCalculator : IResultCalculator
{
    public Result ComputeResult(IEnumerable<Value> values, string fileName)
    {
        ImmutableList<Value> immutableValues = values.ToImmutableList();
        int allTime = new(),
            rowCount = new();
        DateTime minDateTime = new();
        float averageExecutionTime = new(),
            averageIndicator = new(),
            indicatorMedian = new(),
            minIndicator = new(),
            maxIndicator = new();

        Parallel.Invoke(
                () => allTime = ComputeAllTimeSeconds(immutableValues),
                () => minDateTime = GetMinDateTime(immutableValues),
                () => averageExecutionTime = ComputeAverageExecutionTime(immutableValues),
                () => averageIndicator = ComputeAverageIndicator(immutableValues),
                () => indicatorMedian = ComputeIndicatorMedian(immutableValues),
                () => minIndicator = GetMinIndicator(immutableValues),
                () => maxIndicator = GetMaxIndicator(immutableValues),
                () => rowCount = CountRows(immutableValues));

        return new Result(
            fileName,
            allTime,
            minDateTime,
            averageExecutionTime,
            averageIndicator,
            indicatorMedian,
            minIndicator,
            maxIndicator,
            rowCount) 
            { Values = values };
    }

    private int ComputeAllTimeSeconds(ImmutableList<Value> values) =>
        values.Max(value => value.ExecutionTimeSeconds) - values.Min(value => value.ExecutionTimeSeconds);

    private DateTime GetMinDateTime(ImmutableList<Value> values) =>
        values.Min(value => value.DateTime);

    private float ComputeAverageExecutionTime(ImmutableList<Value> values) =>
        ((float)values.Average(value => value.ExecutionTimeSeconds));

    private float ComputeAverageIndicator(ImmutableList<Value> values) =>
        values.Average(value => value.Indicator);

    private float ComputeIndicatorMedian(ImmutableList<Value> values) =>
        values.Select(value => value.Indicator).Median();

    private float GetMaxIndicator(ImmutableList<Value> values) =>
        values.Max(value => value.Indicator);

    private float GetMinIndicator(ImmutableList<Value> values) =>
        values.Min(value => value.Indicator);

    private int CountRows(ImmutableList<Value> values) =>
        values.Count;
}