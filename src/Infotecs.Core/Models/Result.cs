namespace Infotecs.Core.Models;

public class Result : Entity
{
    public IEnumerable<Value> Values { get; private set; }
    public int AllTimeSeconds { get; }
    public DateTime MinimalDateTime { get; }
    public double AverageExecutionTimeSeconds { get; }
    public double IndicatorAverage { get; }
    public double IndicatorMedian { get; }
    public double IndicatorMinimum { get; }
    public double IndicatorMaximum { get; }
    public int RowCount { get; }
    
    public Result(
        IEnumerable<Value> values,
        int allTimeSeconds,
        DateTime minimalDateTime,
        double averageExecutionTimeSeconds,
        double indicatorAverage,
        double indicatorMedian,
        double indicatorMinimum,
        double indicatorMaximum,
        int rowCount) : base()
    {
        Values = values;
        AllTimeSeconds = allTimeSeconds;
        MinimalDateTime = minimalDateTime;
        AverageExecutionTimeSeconds = averageExecutionTimeSeconds;
        IndicatorAverage = indicatorAverage;
        IndicatorMedian = indicatorMedian;
        IndicatorMinimum = indicatorMinimum;
        IndicatorMaximum = indicatorMaximum;
        RowCount = rowCount;
    }
}