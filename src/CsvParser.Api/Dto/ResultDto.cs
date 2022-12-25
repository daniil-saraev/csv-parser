namespace CsvParser.Api.Dto;

public struct ResultDto
{
    public int AllTimeSeconds { get; set; }
    public DateTime MinimalDateTime { get; set; }
    public float AverageExecutionTimeSeconds { get; set; }
    public float IndicatorAverage { get; set; }
    public float IndicatorMedian { get; set; }
    public float IndicatorMinimum { get; set; }
    public float IndicatorMaximum { get; set; }
    public int RowCount { get; }
}