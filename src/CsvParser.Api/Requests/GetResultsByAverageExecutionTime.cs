using System.ComponentModel.DataAnnotations;
using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByAverageExecutionTime : IRequest<SelectedResults>
{
    [Required]
    public int From { get; set; }
    [Required]
    public int To { get; set; }
}