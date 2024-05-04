using APhoto.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APhoto.Infrastructure
{
    public abstract class AbstractRepository<T>(APhotosContext context) : IAbstractRepository<T>
        where T : class
    {
        protected readonly APhotosContext _context = context;

        public async IAsyncEnumerable<T> GetAll(CancellationToken cancellationToken)
        {
            var items = _context.Set<T>().AsAsyncEnumerable().WithCancellation(cancellationToken);
            await foreach (var item in items)
            {
                yield return item;
            }
        }

        public async Task<T?> GetOne(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
            => await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);

        public async Task Create(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            var entry = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
