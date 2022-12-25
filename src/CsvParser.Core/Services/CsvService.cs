using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;

namespace CsvParser.Core.Services;

internal class CsvService : ICsvService
{
    private readonly IValuesParser _valuesParser;
    private readonly IResultCalculator _resultCalculator;
    private readonly IRepository<Result> _resultsRepository;
    private readonly IRepository<Value> _valuesRepository;

    public CsvService(IValuesParser valuesParser, 
                    IResultCalculator resultCalculator, 
                    IRepository<Result> resultsRepository,
                    IRepository<Value> valuesRepository)
    {
        _valuesParser = valuesParser;
        _resultCalculator = resultCalculator;
        _resultsRepository = resultsRepository;
        _valuesRepository = valuesRepository;
        _resultsRepository = resultsRepository;
    }

    public async Task ProcessCsv(Stream stream, string fileName, IErrorLogService logService, CancellationToken cancellationToken = default)
    {
        var values = _valuesParser.ReadValuesFromCsv(stream, fileName, logService);
        var result = _resultCalculator.ComputeResult(values, fileName);
        var existingResult = (await _resultsRepository.GetEntitiesAsync(result => result.FileName == fileName, cancellationToken))
                                .FirstOrDefault();
        if(existingResult != null)
            await _resultsRepository.DeleteEntitiesAsync(new[] { existingResult }, cancellationToken);
        
        await _valuesRepository.AddEntitiesAsync(values, cancellationToken);
        await _resultsRepository.AddEntitiesAsync(new[] { result }, cancellationToken);
    }
}