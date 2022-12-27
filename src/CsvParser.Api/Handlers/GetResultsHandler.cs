using MediatR;
using CsvParser.Api.Requests;
using CsvParser.Api.Responses;
using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Api.Dto;

namespace CsvParser.Api.Handlers;

internal class GetResultsHandler : IRequestHandler<GetResultsByAverageExecutionTime, SelectedResults>,
                                IRequestHandler<GetResultsByAverageIndicator, SelectedResults>,
                                IRequestHandler<GetResultsByDateTime, SelectedResults>,
                                IRequestHandler<GetResultsByFileName, SelectedResults>
{
    private readonly IRepository<Result> _repository;

    public GetResultsHandler(IRepository<Result> repository)
    {
        _repository = repository;
    }

    public async Task<SelectedResults> Handle(GetResultsByAverageExecutionTime request, CancellationToken cancellationToken)
    {
        var results = await _repository.GetEntitiesAsync(
            result => result.AverageExecutionTimeSeconds > request.From
                        && result.AverageExecutionTimeSeconds < request.To,
            cancellationToken
        );
        return CreateResponse(results);
    }

    public async Task<SelectedResults> Handle(GetResultsByAverageIndicator request, CancellationToken cancellationToken)
    {
        var results = await _repository.GetEntitiesAsync(
            result => result.IndicatorAverage > request.From
                        && result.IndicatorAverage < request.To,
            cancellationToken
        );
        return CreateResponse(results);
    }

    public async Task<SelectedResults> Handle(GetResultsByDateTime request, CancellationToken cancellationToken)
    {
        var results = await _repository.GetEntitiesAsync(
            result => result.MinimalDateTime > request.From
                        && result.MinimalDateTime < request.Until,
            cancellationToken
        );
        return CreateResponse(results);
    }

    public async Task<SelectedResults> Handle(GetResultsByFileName request, CancellationToken cancellationToken)
    {
        var results = await _repository.GetEntitiesAsync(
            result => result.FileName == request.FileName,
            cancellationToken
        );
        return CreateResponse(results);
    }

    private SelectedResults CreateResponse(IEnumerable<Result> results)
    {
        return new SelectedResults
        {
            Results = results.Select(result => new ResultDto
            {
                AllTimeSeconds = result.AllExecutionTimeSeconds,
                AverageExecutionTimeSeconds = result.AverageExecutionTimeSeconds,
                IndicatorAverage = result.IndicatorAverage,
                IndicatorMaximum = result.IndicatorMaximum,
                IndicatorMedian = result.IndicatorMedian,
                IndicatorMinimum = result.IndicatorMinimum,
                MinimalDateTime = result.MinimalDateTime,
                RowCount = result.RowCount
            })
        }; 
    }
}