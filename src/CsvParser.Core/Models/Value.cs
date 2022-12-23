using CsvParser.Core.Validation;

namespace CsvParser.Core.Models;

public class Value : Entity
{
    public Result Result { get; private set; } = null!;
    public string ResultId { get; private set; } = null!;
    public DateTime DateTime { get; }
    public int ExecutionTimeSeconds { get; }
    public double Indicator { get; }

    public Value(DateTime dateTime, int executionTimeSeconds, double indicator) : base()
    {
        Check.DateTime(dateTime);
        Check.ExecutionTime(executionTimeSeconds);
        Check.Indicator(indicator);
        DateTime = dateTime;
        ExecutionTimeSeconds = executionTimeSeconds;
        Indicator = indicator;
    }
}