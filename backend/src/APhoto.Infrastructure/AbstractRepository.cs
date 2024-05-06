using APhoto.Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace APhoto.Infrastructure
{
    public abstract class AbstractRepository<T>(DbContext context) : IAbstractRepository<T>
        where T : class
    {
        protected readonly DbContext _context = context;

        public async IAsyncEnumerable<T> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var items = _context.Set<T>().AsAsyncEnumerable().WithCancellation(cancellationToken);
            await foreach (var item in items)
            {
                yield return item;
            }
        }

        public async Task<IServiceResult<T>> GetOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);

                if (result is null)
                {
                    return ServiceResult<T>.Fail("The predicate produced no result.");
                }

                return ServiceResult<T>.Success(result);
            }
            catch (Exception)
            {
                return ServiceResult<T>.Fail("The predicate produced more than one element.");
            }
        }

        public async IAsyncEnumerable<T> GetManyAsync(Expression<Func<T, bool>> predicate, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var queryable = _context.Set<T>().Where(predicate);
            await foreach(var item in queryable.AsAsyncEnumerable().WithCancellation(cancellationToken))
            {
                yield return item;
            }
        }

        public async Task<IServiceResult> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                ServiceResult.Fail(ex.Message);
                throw;
            }
        }

        public async Task<IServiceResult> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                var entry = _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                ServiceResult.Fail(ex.Message);
                throw;
            }
        }

        public async Task<IServiceResult> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                ServiceResult.Fail(ex.Message);
                throw;
            }
        }
    }
}
