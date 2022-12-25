using MediatR;
using CsvParser.Api.Requests;
using CsvParser.Api.Responses;
using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Api.Dto;

namespace CsvParser.Api.Handlers;

internal class GetValuesHandler : IRequestHandler<GetValuesByFileName, SelectedValues>
{
    private readonly IRepository<Value> _repository;

    public GetValuesHandler(IRepository<Value> repository)
    {
        _repository = repository;
    }

    public async Task<SelectedValues> Handle(GetValuesByFileName request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetEntitiesAsync(
            value => value.FileName == request.FileName,
            cancellationToken
        );
        return CreateResponse(values);
    }

    private SelectedValues CreateResponse(IEnumerable<Value>? values)
    {
        if(values == null)
            return new SelectedValues { Values = new List<ValueDto>() };
        return new SelectedValues
        {
            Values = values.Select(value => new ValueDto
            {
                DateTime = value.DateTime,
                ExecutionTimeSeconds = value.ExecutionTimeSeconds,
                Indicator = value.Indicator
            })
        }; 
    }
}