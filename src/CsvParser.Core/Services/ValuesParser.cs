using CsvHelper;
using CsvHelper.Configuration;
using CsvParser.Core.Configuration;
using CsvParser.Core.Exceptions;
using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Core.Validation;
using System.Globalization;

namespace CsvParser.Core.Services;

/// <summary>
/// <inheritdoc cref="IValuesParser"/>
/// </summary>
internal class ValuesParser : IValuesParser
{
    private readonly CsvFormatConfiguration _formatConfig;
    private readonly CsvConfiguration _readerConfig;
    private int _errorCount;

    public ValuesParser(CsvFormatConfiguration configuration)
    {
        _formatConfig = configuration;
        _readerConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = _formatConfig.HasHeaders,
            Delimiter = _formatConfig.Delimiter,
        };
    }

    public ParsingResult ReadValuesFromCsv(Stream stream)
    {
        using (var streamReader = new StreamReader(stream))
        using (var csvReader = new CsvReader(streamReader, _readerConfig))
        {
            var values = new List<Value>(); 
            while (csvReader.Read())
            {
                if (!Valid.RowCount(csvReader.Parser.Row)) // Check if the number of rows exceeds a limit
                    throw new InvalidRowCountException();
                TryAddNewValue(values, csvReader); // Create and add a valid value, skip invalid.
            }
            if (!values.Any()) // Check if we got any valid values.
                throw new InvalidRowCountException();
            return new ParsingResult(values, _errorCount);
        }
    }

    private void TryAddNewValue(List<Value> values, CsvReader csvReader)
    {
        var dateTimeIsValid = TryParseDateTime(csvReader.GetField<string>(0), out var dateTime);
        var executionTimeSeconds = csvReader.GetField<int>(1);
        var indicator = csvReader.GetField<float>(2);

        // Check if any of the values are invalid
        if (!dateTimeIsValid || !ValidFields(dateTime, executionTimeSeconds, indicator))
            _errorCount++;
        else
            values.Add(new Value(
                dateTime,
                executionTimeSeconds,
                indicator));
    }

    private bool TryParseDateTime(string? s, out DateTime dateTime)
    {
        return DateTime.TryParseExact(
                s,
                _formatConfig.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime);
    }

    private bool ValidFields(DateTime dateTime, int executionTime, float indicator)
    {
        return Valid.DateTime(dateTime)
            && Valid.ExecutionTime(executionTime)
            && Valid.Indicator(indicator);
    }
}
