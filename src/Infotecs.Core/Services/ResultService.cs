using Infotecs.Core.Interfaces;
using Infotecs.Core.Models;
using MathNet.Numerics.Statistics;
using System.Collections.Immutable;

namespace Infotecs.Core.Services;

public class ResultService : IResultService
{
    public Result ComputeResult(IEnumerable<Value> values)
    {
        ImmutableList<Value> immutableValues = values.ToImmutableList();
        int allTime = new(), 
            rowCount = new();
        DateTime minDateTime = new();
        double averageExecutionTime = new(), 
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
            values,
            allTime,
            minDateTime,
            averageExecutionTime,
            averageIndicator,
            indicatorMedian,
            minIndicator,
            maxIndicator,
            rowCount);
    }

    private int ComputeAllTimeSeconds(ImmutableList<Value> values) =>
        values.Max(value => value.ExecutionTimeSeconds) - values.Min(value => value.ExecutionTimeSeconds);

    private DateTime GetMinDateTime(ImmutableList<Value> values) =>
        values.Min(value => value.DateTime);

    private double ComputeAverageExecutionTime(ImmutableList<Value> values) =>
        values.Average(value => value.ExecutionTimeSeconds);

    private double ComputeAverageIndicator(ImmutableList<Value> values) =>
        values.Average(value => value.Indicator);

    private double ComputeIndicatorMedian(ImmutableList<Value> values) =>
        values.Select(value => value.Indicator).Median();

    private double GetMaxIndicator(ImmutableList<Value> values) =>
        values.Max(value => value.Indicator);

    private double GetMinIndicator(ImmutableList<Value> values) =>
        values.Min(value => value.Indicator);

    private int CountRows(ImmutableList<Value> values) =>
        values.Count;
}