using CsvHelper;
using CsvHelper.Configuration;
using CsvParser.Core.Configuration;
using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Core.Validation;
using System.Globalization;
using ValidationException = CsvParser.Core.Exceptions.ValidationException;

namespace CsvParser.Core.Services;

public class CsvService : ICsvService
{
    private readonly ILoggerService<CsvService> _logger;
    private readonly CsvFormatConfiguration _formatConfig;
    private readonly CsvConfiguration _readerConfig;

    public CsvService(CsvFormatConfiguration configuration, ILoggerService<CsvService> logger)
    {
        _formatConfig = configuration;
        _logger = logger;
        _readerConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = _formatConfig.HasHeaders,
            Delimiter = _formatConfig.Delimiter,
        };
    }

    public IEnumerable<Value> ReadValuesFromCsv(Stream stream)
    {
        using (var streamReader = new StreamReader(stream))
        using (var csvReader = new CsvReader(streamReader, _readerConfig))
        {
            var values = new List<Value>();
            while (csvReader.Read())
            {
                Check.RowCount(csvReader.Parser.Row);
                TryAddNewValue(values, csvReader);
            }
            return values;
        }
    }

    private void TryAddNewValue(List<Value> values, CsvReader csvReader)
    {
        try
        {
            var value = new Value(
                DateTime.ParseExact(csvReader.GetField<string>(0), _formatConfig.DateTimeFormat, CultureInfo.InvariantCulture),
                csvReader.GetField<int>(1),
                csvReader.GetField<double>(2));
            values.Add(value);
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex.Message, $"Row {csvReader.Parser.Row}");
        }
    }
}
