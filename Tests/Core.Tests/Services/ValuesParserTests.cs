using System.Globalization;
using System.Text;

namespace Core.Tests.Services;

public class ValuesParserTests
{
    private readonly ValuesParser _valuesParser;
    private readonly CsvFormatConfiguration _configuration;

    public ValuesParserTests()
    {
        _configuration = new CsvFormatConfiguration
        {
            HasHeaders = false,
            Delimiter = ";",
            DateTimeFormat = "yyyy-MM-dd_HH-mm-ss"
        };
        _valuesParser = new ValuesParser(_configuration);
    }

    [Fact]
    public void ReadValuesFromCsvIfStreamIsEmptyTest()
    {
        // Arrange
        var testStream = new MemoryStream();

        // Act & Assert
        Assert.Throws<InvalidRowCountException>(() => _valuesParser.ReadValuesFromCsv(testStream));
    }

    [Fact]
    public void ReadValuesFromCsvIfAllValuesAreInvalidTest()
    {
        // Arrange
        const string invalidData = "1234;1234;1234";
        var testStream = new MemoryStream(
            Encoding.UTF8.GetBytes(invalidData));

        // Act & Assert
        Assert.Throws<InvalidRowCountException>(() => _valuesParser.ReadValuesFromCsv(testStream));
    }

    [Fact]
    public void ReadValuesFromCsvIfSomeValuesAreInvalidTest()
    {
        // Arrange
        const string invalidData = "1234;1234;1234";
        const string validData = "2022-03-18_09-18-17;1744;1632,472";
        var testStream = new MemoryStream(
            Encoding.UTF8.GetBytes($"{invalidData}\n" +
            $"{validData}"));

        // Act
        var parsingResult = _valuesParser.ReadValuesFromCsv(testStream);

        // Assert
        Assert.True(parsingResult.ParsingErrorCount == 1);
        Assert.Single(parsingResult.Values);
    }

    [Fact]
    public void ReadValuesFromCsvTest()
    {
        // Arrange
        const string dateTime = "2022-03-18_09-18-17";
        const int executionTime = 1744;
        const float indicator = 1632.472f;
        var testStream = new MemoryStream(
            Encoding.UTF8.GetBytes($"{dateTime};{executionTime};{indicator}"));

        // Act
        var parsingResult = _valuesParser.ReadValuesFromCsv(testStream);
        var value = parsingResult.Values.First();

        // Assert
        Assert.True(parsingResult.ParsingErrorCount == 0);
        Assert.True(value.DateTime == DateTime.ParseExact(dateTime, _configuration.DateTimeFormat, CultureInfo.InvariantCulture)
            && value.ExecutionTimeSeconds == executionTime
            && value.Indicator == indicator);
    }
}
