using CsvParser.Api.Dto;

namespace CsvParser.Api.Responses;

public class SelectedResults
{
    public IEnumerable<ResultDto> Results { get; set; } = null!;
}