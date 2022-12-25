using System.ComponentModel.DataAnnotations;
using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByAverageIndicator : IRequest<SelectedResults>
{
    [Required]
    public float From { get; set; }
    [Required]
    public float To { get; set; }
}