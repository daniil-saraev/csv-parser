using System.ComponentModel.DataAnnotations;
using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class GetValuesByFileName : IRequest<SelectedValues>
{
    [Required]
    public string FileName { get; set; } = null!;
}