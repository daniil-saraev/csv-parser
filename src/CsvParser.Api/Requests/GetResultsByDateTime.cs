using System.ComponentModel.DataAnnotations;
using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByDateTime : IRequest<SelectedResults>
{
    [Required]
    public DateTime From { get; set; }
    [Required]
    public DateTime Until { get; set; }
}