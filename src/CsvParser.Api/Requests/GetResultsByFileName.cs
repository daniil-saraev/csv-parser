using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByFileName : IRequest<SelectedResults>
{
    public string FileName { get; set; } = null!;
}