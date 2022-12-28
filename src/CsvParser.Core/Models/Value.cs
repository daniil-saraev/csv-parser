namespace CsvParser.Core.Models;

public class Value : Entity
{
    public string FileName { get; private set; } = null!;
    public DateTime DateTime { get; }
    public int ExecutionTimeSeconds { get; }
    public float Indicator { get; }

    internal Value(DateTime dateTime, int executionTimeSeconds, float indicator)
    {
        DateTime = dateTime;
        ExecutionTimeSeconds = executionTimeSeconds;
        Indicator = indicator;
    }
}