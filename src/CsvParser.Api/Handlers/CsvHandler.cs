using CsvParser.Api.Requests;
using CsvParser.Api.Responses;
using CsvParser.Core.Interfaces;
using MediatR;

namespace CsvParser.Api.Handlers;

internal class CsvHandler : IRequestHandler<UploadCsv, CsvUploaded>
{
    private readonly ICsvService _csvService;

    public CsvHandler(ICsvService csvService)
    {
        _csvService = csvService;
    }

    public async Task<CsvUploaded> Handle(UploadCsv request, CancellationToken cancellationToken)
    {
        var parsingErrors = await _csvService.ProcessCsv(request.File.OpenReadStream(),
                                    request.File.FileName,
                                    cancellationToken);
        return new CsvUploaded
        {
            TotalParsingErrors = parsingErrors
        };
    }
}