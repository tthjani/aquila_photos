using System;
using System.Linq.Expressions;

namespace APhoto.Infrastructure
{
    public interface IAbstractRepository<T> where T : class
    {
        IAsyncEnumerable<T> GetAll(CancellationToken cancellationToken);

        Task<T?> GetOne(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task Create(T entity, CancellationToken cancellationToken);

        Task Update(T entity, CancellationToken cancellationToken);

        Task Delete(T entity, CancellationToken cancellationToken);
    }
}
