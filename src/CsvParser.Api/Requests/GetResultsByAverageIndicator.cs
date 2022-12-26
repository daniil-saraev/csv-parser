using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByAverageIndicator : IRequest<SelectedResults>
{
    public float From { get; set; }
    public float To { get; set; }
}