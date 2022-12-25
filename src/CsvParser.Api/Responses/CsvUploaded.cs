namespace CsvParser.Api.Responses;

public class CsvUploaded
{
    public IEnumerable<string> ParsingErrors { get; set; } = null!;
}