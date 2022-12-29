using GenericUnitOfWork.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GenericUnitOfWork.DAL.Data;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<TEntity,Key> GetRepository<TEntity,Key>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface IUnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
{
    TContext Context { get; }
}
