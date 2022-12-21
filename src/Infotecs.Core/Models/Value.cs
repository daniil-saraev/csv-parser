namespace Infotecs.Core.Models;

public class Value : Entity
{
    public Result Result { get; private set; } = null!;
    public string ResultId { get; private set; } = null!;
    public DateTime DateTime { get; }
    public int TimeSeconds { get; }
    public double Indicator { get; }
    public string FileName { get; }

    public Value(DateTime dateTime, int seconds, double indicator, string fileName) : base()
    {
        DateTime = dateTime;
        TimeSeconds = seconds;
        Indicator = indicator;
        FileName = fileName;
    }
}