using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetValuesByFileName : IRequest<SelectedValues>
{
    public string FileName { get; set; } = null!;
}