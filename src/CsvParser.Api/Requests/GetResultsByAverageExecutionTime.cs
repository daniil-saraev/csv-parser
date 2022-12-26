using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByAverageExecutionTime : IRequest<SelectedResults>
{
    public int From { get; set; }
    public int To { get; set; }
}