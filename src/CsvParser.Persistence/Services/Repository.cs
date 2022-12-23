using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CsvParser.Persistence.Services
{
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

        public async Task DeleteEntitiesAsync(Predicate<T> predicate, CancellationToken cancellationToken = default)
        {
            await _dataContext.Set<T>().Where(entity => predicate(entity)).ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(Predicate<T>? predicate = null, CancellationToken cancellationToken = default)
        {
            if (predicate != null)
                return await _dataContext.Set<T>().Where(entity => predicate(entity)).ToListAsync(cancellationToken);
            else
                return await _dataContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task UpdateEntitiesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dataContext.Set<T>().UpdateRange(entities);
            await _dataContext.SaveChangesAsync();
        }
    }
}
