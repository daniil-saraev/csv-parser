using CsvParser.Core.Exceptions;

namespace CsvParser.Core.Validation;

internal static class Check
{
    private static DateTime MIN_DATE_TIME => new(2000, 1, 1);
    private static DateTime MAX_DATE_TIME => System.DateTime.Now;
    private static int MIN_EXECUTION_TIME => 0;
    private static int MIN_INDICATOR_VALUE => 0;
    private static int MAX_ROW_COUNT => 10000;
    private static int MIN_ROW_COUNT => 1;

    public static void RowCount(int rowCount)
    {
        if (rowCount > MAX_ROW_COUNT || rowCount < MIN_ROW_COUNT)
            throw new InvalidRowCountException($"Invalid number of rows: {rowCount}");
    }

    public static void DateTime(DateTime dateTime)
    {
        if (dateTime > MAX_DATE_TIME || dateTime < MIN_DATE_TIME)
            throw new InvalidDateTimeException($"Invalid date value: {dateTime}");
    }

    public static void ExecutionTime(int executionTimeSeconds)
    {
        if (executionTimeSeconds < MIN_EXECUTION_TIME)
            throw new InvalidExecutionTimeException($"Invalid execution time value: {executionTimeSeconds}");
    }

    public static void Indicator(float indicator)
    {
        if (indicator < MIN_INDICATOR_VALUE)
            throw new InvalidIndicatorException($"Invalid indicator value: {indicator}");
    }
}
