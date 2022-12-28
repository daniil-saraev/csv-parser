using static CsvParser.Core.Validation.Valid.Constraints;

namespace CsvParser.Core.Validation;

/// <summary>
/// Contains domain validation rules.
/// </summary>
public static class Valid
{
    public static class Constraints
    {
        public static DateTime MIN_DATE_TIME => new(2000, 1, 1);
        public static DateTime MAX_DATE_TIME => System.DateTime.Now;
        public static int MIN_EXECUTION_TIME => 0;
        public static int MIN_INDICATOR_VALUE => 0;
        public static int MAX_ROW_COUNT => 10000;
        public static int MIN_ROW_COUNT => 1;
    }
    
    /// <summary>
    /// Returns true if the number of rows falls within the allowed range. 
    /// </summary>
    internal static bool RowCount(int rowCount)
    {
        if (rowCount > MAX_ROW_COUNT || rowCount < MIN_ROW_COUNT)
            return false;
        else return true;
    }

    /// <summary>
    /// Returns true if the <see cref="System.DateTime"/> value falls within the allowed range. 
    /// </summary>
    internal static bool DateTime(DateTime dateTime)
    {
        if (dateTime > MAX_DATE_TIME || dateTime < MIN_DATE_TIME)
            return false;
        else return true;
    }

    /// <summary>
    /// Returns true if the execution time value falls within the allowed range. 
    /// </summary>
    internal static bool ExecutionTime(int executionTimeSeconds)
    {
        if (executionTimeSeconds < MIN_EXECUTION_TIME)
            return false;
        else return true;
    }

    /// <summary>
    /// Returns true if the indicator value falls within the allowed range. 
    /// </summary>
    internal static bool Indicator(float indicator)
    {
        if (indicator < MIN_INDICATOR_VALUE)
            return false;
        else return true;
    }
}
