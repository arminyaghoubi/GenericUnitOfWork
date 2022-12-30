using GenericUnitOfWork.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GenericUnitOfWork.DAL.Data;

public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IRepositoryFactory
    where TContext : DbContext
{
    private readonly TContext _context;

    public UnitOfWork(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(_context));
    }

    public TContext Context => _context;

    public IRepository<TEntity,TKey> GetRepository<TEntity,TKey>() where TEntity : class =>
        new Repository<TEntity,TKey>(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync(cancellationToken);

    public async ValueTask DisposeAsync()
    {
        if(_context is not null)
            await _context.DisposeAsync();
    }
}