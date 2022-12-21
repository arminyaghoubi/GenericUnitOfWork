using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;

namespace GenericUnitOfWork.DAL.Repositories;

public interface IRepository<TEntity>
    where TEntity : class
{
    Task<IPagedList<TEntity>> GetPagedListAsync(int page, int pageSize);
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
}
