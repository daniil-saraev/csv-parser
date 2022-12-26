using CsvParser.Core.Validation;

namespace CsvParser.Core.Models;

public class Value : Entity
{
    public string FileName { get; private set; } = null!;
    public DateTime DateTime { get; }
    public int ExecutionTimeSeconds { get; }
    public float Indicator { get; }

    public Value(DateTime dateTime, int executionTimeSeconds, float indicator)
    {
        Check.DateTime(dateTime);
        Check.ExecutionTime(executionTimeSeconds);
        Check.Indicator(indicator);
        DateTime = dateTime;
        ExecutionTimeSeconds = executionTimeSeconds;
        Indicator = indicator;
    }
}