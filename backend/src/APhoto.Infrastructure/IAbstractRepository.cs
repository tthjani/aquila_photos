using System;
using System.Linq.Expressions;

namespace APhoto.Infrastructure
{
    public interface IAbstractRepository<T> where T : class
    {
        IAsyncEnumerable<T> GetAllAsync(CancellationToken cancellationToken);

        Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task CreateAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
