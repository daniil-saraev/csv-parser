using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CsvParser.Persistence.Services
{
    /// <summary>
    /// <inheritdoc cref="IRepository{T}"/>
    /// </summary>
    internal class Repository<T> : IRepository<T> where T : Entity
    {
        public readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dataContext.Set<T>().AddRangeAsync(entities, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dataContext.Set<T>().RemoveRange(entities);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            if (predicate != null)
                return await _dataContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
            else
                return await _dataContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
