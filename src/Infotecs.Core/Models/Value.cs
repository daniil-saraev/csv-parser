using Infotecs.Core.Validation;

namespace Infotecs.Core.Models;

public class Value : Entity
{
    public Result Result { get; private set; } = null!;
    public string ResultId { get; private set; } = null!;
    public DateTime DateTime { get; }
    public int ExecutionTimeSeconds { get; }
    public double Indicator { get; }
    public string FileName { get; }

    public Value(DateTime dateTime, int executionTimeSeconds, double indicator, string fileName) : base()
    {
        Check.DateTime(dateTime);
        Check.ExecutionTime(executionTimeSeconds);
        Check.Indicator(indicator);
        DateTime = dateTime;
        ExecutionTimeSeconds = executionTimeSeconds;
        Indicator = indicator;
        FileName = fileName;
    }
}