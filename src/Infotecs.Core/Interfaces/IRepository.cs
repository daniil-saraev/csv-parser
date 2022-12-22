using Infotecs.Core.Models;

namespace Infotecs.Core.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetEntitiesAsync(Predicate<T>? predicate = null, CancellationToken cancellationToken = default);

    Task AddEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task UpdateEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task DeleteEntitiesAsync(Predicate<T> predicate, CancellationToken cancellationToken = default);
}