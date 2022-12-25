using System.ComponentModel.DataAnnotations;
using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetResultsByFileName : IRequest<SelectedResults>
{
    [Required]
    public string FileName { get; set; } = null!;
}