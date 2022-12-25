using CsvParser.Api.Requests;
using CsvParser.Api.Responses;
using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using MediatR;

namespace CsvParser.Api.Handlers;

internal class CsvHandler : IRequestHandler<UploadCsv, CsvUploaded>
{
    private readonly ICsvService _csvService;
    private readonly IErrorLogService _logger;

    public CsvHandler(ICsvService csvService, IErrorLogService logService)
    {
        _csvService = csvService;
        _logger = logService;
    }

    public async Task<CsvUploaded> Handle(UploadCsv request, CancellationToken cancellationToken)
    {
        await _csvService.ProcessCsv(request.File.OpenReadStream(),
                                    request.File.FileName,
                                    _logger,
                                    cancellationToken);
        return new CsvUploaded { ParsingErrors = _logger.Errors };
    }
}