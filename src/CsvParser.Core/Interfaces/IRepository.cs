using CsvParser.Core.Models;

namespace CsvParser.Core.Interfaces;

/// <summary>
/// Encapsulates database interactions.
/// </summary>
/// <typeparam name="T">Entity that is peristed to database.</typeparam>
public interface IRepository<T> where T : Entity
{
    /// <summary>
    /// Retrieves entities based on predicate if not null, otherwise, retrieves all records.
    /// </summary>
    /// <param name="predicate">A query filter.</param>
    /// <returns>A collection of entities.</returns>
    Task<IEnumerable<T>> GetEntitiesAsync(Func<T, bool>? predicate = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds entities to database.
    /// </summary>
    Task AddEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes entites from database.
    /// </summary>
    Task DeleteEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}