using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using GenericUnitOfWork.DAL.Data;
using GenericUnitOfWork.DAL.Repositories;
using System.Linq.Expressions;

namespace GenericUnitOfWork.BL.Services;

public abstract class BaseService<TEntity, TKey, TResult> : IBaseService<TEntity, TKey, TResult>
    where TEntity : BaseModel<TKey>
    where TResult : class
{
    protected readonly IUnitOfWork _unitOfWork;

    protected abstract TEntity ViewModelToModel(TResult viewModel);
    protected abstract void ChangeForUpdate(TEntity entity, TResult viewModel);

    protected IRepository<TEntity, TKey> Repository => _unitOfWork.GetRepository<TEntity, TKey>();

    public BaseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public abstract IPagedList<TResult> GetPagedList(int page = 1,int pageSize = 20);

    public abstract Task<TResult?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
        bool disableTracking = true,
        CancellationToken cancellationToken = default);

    public abstract Task<TResult?> GetByIdAsync(TKey key,CancellationToken cancellationToken = default);

    public async Task<TEntity> InsertAsync(TResult viewModel, CancellationToken cancellationToken = default)
    {
        var result= await Repository.InsertAsync(ViewModelToModel(viewModel), cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task UpdateAsync(TKey key, TResult viewModel, CancellationToken cancellationToken = default)
    {
        var entity = await Repository.GetByIdAsync(key, cancellationToken);
        if (entity is not null)
        {
            ChangeForUpdate(entity, viewModel);
            Repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(TKey key, CancellationToken cancellationToken = default)
    {
        var entity = await Repository.GetByIdAsync(key, cancellationToken);
        if (entity is not null)
        {
            Repository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
