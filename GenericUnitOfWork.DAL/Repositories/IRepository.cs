using GenericUnitOfWork.Common.ViewModels;
using System.Linq.Expressions;

namespace GenericUnitOfWork.DAL.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : class
{
    IPagedList<TEntity> GetPagedList(
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        Expression<Func<TEntity, object>> order = null,
        bool ascending = true,
        int page = 1,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);

    IPagedList<TResult> GetPagedList<TResult>(
        Func<TEntity, TResult> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        Expression<Func<TEntity, object>> order = null,
        bool ascending = true,
        int page = 1,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);

    Task<TEntity?> GetByIdAsync(TKey key, CancellationToken cancellationToken);

    Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);

    Task<TResult?> GetFirstOrDefaultAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);

    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    void UpdateRange(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteRange(IEnumerable<TEntity> entities);
}
