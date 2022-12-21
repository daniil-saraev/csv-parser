using Infotecs.Core.Models;

namespace Infotecs.Core.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetEntities(Predicate<bool, T> predicate = null, CancellationToken cancellationToken = default);

    Task AddEntity(T entity, CancellationToken cancellationToken = default);

    Task AddEntities(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task UpdateEntity(T entity, CancellationToken cancellationToken = default);

    Task UpdateEntities(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}