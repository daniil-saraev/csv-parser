using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;

namespace CsvParser.Core.Services;

internal class CsvService : ICsvService
{
    private readonly IValuesParser _valuesParser;
    private readonly IResultCalculator _resultCalculator;
    private readonly IRepository<Result> _resultsRepository;
    private readonly IErrorLogService _logService;

    public CsvService(IValuesParser valuesParser, 
                    IResultCalculator resultCalculator, 
                    IRepository<Result> resultsRepository,
                    IErrorLogService errorLogService)
    {
        _valuesParser = valuesParser;
        _resultCalculator = resultCalculator;
        _resultsRepository = resultsRepository;
        _resultsRepository = resultsRepository;
        _logService = errorLogService;
    }

    public async Task<int> ProcessCsv(Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        var values = _valuesParser.ReadValuesFromCsv(stream, _logService);
        var result = _resultCalculator.ComputeResult(values, fileName);

        var existingResult = (await _resultsRepository.GetEntitiesAsync(
            result => result.FileName == fileName, cancellationToken))
            .FirstOrDefault();
        if (existingResult != null)
            await _resultsRepository.DeleteEntitiesAsync(new[] { existingResult }, cancellationToken);
        await _resultsRepository.AddEntitiesAsync(new[] { result }, cancellationToken);
        
        return _logService.ErrorCount;
    }
}