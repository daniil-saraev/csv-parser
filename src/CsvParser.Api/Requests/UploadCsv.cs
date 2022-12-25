using System.ComponentModel.DataAnnotations;
using CsvParser.Api.Responses;
using MediatR;

namespace CsvParser.Api.Requests;

public class UploadCsv : IRequest<CsvUploaded>
{
    public IFormFile File { get; set; } = null!;
}
