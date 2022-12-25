namespace CsvParser.Api.Dto;

public struct ValueDto
{
    public DateTime DateTime { get; set; }
    public int ExecutionTimeSeconds { get; set; }
    public float Indicator { get; set; }
}