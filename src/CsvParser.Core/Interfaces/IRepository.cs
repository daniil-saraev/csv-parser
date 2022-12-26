using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetEntitiesAsync(Func<T, bool>? predicate = null, CancellationToken cancellationToken = default);

    Task AddEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task DeleteEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}