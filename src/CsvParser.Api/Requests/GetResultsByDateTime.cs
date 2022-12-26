using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByDateTime : IRequest<SelectedResults>
{
    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}