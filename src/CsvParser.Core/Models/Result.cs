namespace CsvParser.Core.Models;

public class Result : Entity
{
    public string FileName { get; }
    public IEnumerable<Value> Values { get; init; } = null!;
    public int AllExecutionTimeSeconds { get; }
    public DateTime MinimalDateTime { get; }
    public float AverageExecutionTimeSeconds { get; }
    public float IndicatorAverage { get; }
    public float IndicatorMedian { get; }
    public float IndicatorMinimum { get; }
    public float IndicatorMaximum { get; }
    public int RowCount { get; }

    internal Result(
        string fileName,
        int allExecutionTimeSeconds,
        DateTime minimalDateTime,
        float averageExecutionTimeSeconds,
        float indicatorAverage,
        float indicatorMedian,
        float indicatorMinimum,
        float indicatorMaximum,
        int rowCount)
    {
        FileName = fileName;
        AllExecutionTimeSeconds = allExecutionTimeSeconds;
        MinimalDateTime = minimalDateTime;
        AverageExecutionTimeSeconds = averageExecutionTimeSeconds;
        IndicatorAverage = indicatorAverage;
        IndicatorMedian = indicatorMedian;
        IndicatorMinimum = indicatorMinimum;
        IndicatorMaximum = indicatorMaximum;
        RowCount = rowCount;
    }
}