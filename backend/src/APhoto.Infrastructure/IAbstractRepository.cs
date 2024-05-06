using APhoto.Infrastructure.Utility;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace APhoto.Infrastructure
{
    public interface IAbstractRepository<T> where T : class
    {
        IAsyncEnumerable<T> GetAllAsync(CancellationToken cancellationToken);

        Task<IServiceResult<T>> GetOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        IAsyncEnumerable<T> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task<IServiceResult> CreateAsync(T entity, CancellationToken cancellationToken);

        Task<IServiceResult> UpdateAsync(T entity, CancellationToken cancellationToken);

        Task<IServiceResult> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
