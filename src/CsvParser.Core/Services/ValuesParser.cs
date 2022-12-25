using CsvHelper;
using CsvHelper.Configuration;
using CsvParser.Core.Configuration;
using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Core.Validation;
using System.Globalization;
using ValidationException = CsvParser.Core.Exceptions.ValidationException;

namespace CsvParser.Core.Services;

internal class ValuesParser : IValuesParser
{
    private readonly CsvFormatConfiguration _formatConfig;
    private readonly CsvConfiguration _readerConfig;

    public ValuesParser(CsvFormatConfiguration configuration)
    {
        _formatConfig = configuration;
        _readerConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = _formatConfig.HasHeaders,
            Delimiter = _formatConfig.Delimiter,
        };
    }

    public IEnumerable<Value> ReadValuesFromCsv(Stream stream, string fileName, IErrorLogService logService)
    {
        using (var streamReader = new StreamReader(stream))
        using (var csvReader = new CsvReader(streamReader, _readerConfig))
        {
            var values = new List<Value>();
            while (csvReader.Read())
            {
                Check.RowCount(csvReader.Parser.Row);
                TryAddNewValue(values, csvReader, fileName, logService);
            }
            return values;
        }
    }

    private void TryAddNewValue(List<Value> values, CsvReader csvReader, string fileName, IErrorLogService logService)
    {
        try
        {
            var value = new Value(
                fileName,
                DateTime.ParseExact(csvReader.GetField<string>(0), _formatConfig.DateTimeFormat, CultureInfo.InvariantCulture),
                csvReader.GetField<int>(1),
                csvReader.GetField<float>(2));
            values.Add(value);
        }
        catch (ValidationException ex)
        {
            logService.LogError(ex.Message, $"Row {csvReader.Parser.Row}");
        }
    }
}
