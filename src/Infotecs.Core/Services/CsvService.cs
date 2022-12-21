using CsvHelper;
using CsvHelper.Configuration;
using Infotecs.Core.Interfaces;
using Infotecs.Core.Models;
using System.Globalization;

namespace Infotecs.Core.Services
{
    public class CsvService : ICsvService
    {
        public Task<IEnumerable<Value>> ReadValuesFromCsv(Stream stream, string fileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ";"
            };
            using (var streamReader = new StreamReader(stream))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = new List<Value>();
                while (csvReader.Read())
                {
                    var record = new Value(
                        DateTime.ParseExact(csvReader.GetField<string>(0), "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture),
                        csvReader.GetField<int>(1),
                        csvReader.GetField<double>(2),
                        fileName);
                    records.Add(record);
                }
                return Task.FromResult<IEnumerable<Value>>(records);
            }
        }
    }
}
