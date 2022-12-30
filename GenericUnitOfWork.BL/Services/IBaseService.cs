using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using System.Linq.Expressions;

namespace GenericUnitOfWork.BL.Services;

public interface IBaseService<TEntity, TKey, TResult>
    where TEntity : BaseModel<TKey>
    where TResult : class
{
    abstract IPagedList<TResult> GetPagedList(int page = 1, int pageSize = 20);

    abstract Task<TResult?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
        bool disableTracking = true,
        CancellationToken cancellationToken = default);

    Task<TResult?> GetByIdAsync(TKey key, CancellationToken cancellationToken = default);

    Task<TEntity> InsertAsync(TResult viewModel, CancellationToken cancellationToken = default);

    Task UpdateAsync(TKey key, TResult viewModel, CancellationToken cancellationToken = default);

    Task DeleteAsync(TKey key, CancellationToken cancellationToken = default);
}