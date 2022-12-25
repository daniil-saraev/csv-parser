using CsvParser.Api.Dto;

namespace CsvParser.Api.Responses;

public class SelectedValues
{
    public IEnumerable<ValueDto> Values { get; set; } = null!;
}