using CsvParser.Core.Validation;

namespace CsvParser.Core.Models;

public class Value : Entity
{
    public string FileName { get; }
    public Result Result { get; private set; } = null!;
    public string ResultId { get; private set; } = null!;
    public DateTime DateTime { get; }
    public int ExecutionTimeSeconds { get; }
    public float Indicator { get; }

    public Value(string fileName, DateTime dateTime, int executionTimeSeconds, float indicator) : base()
    {
        Check.DateTime(dateTime);
        Check.ExecutionTime(executionTimeSeconds);
        Check.Indicator(indicator);
        FileName = fileName;
        DateTime = dateTime;
        ExecutionTimeSeconds = executionTimeSeconds;
        Indicator = indicator;
    }
}