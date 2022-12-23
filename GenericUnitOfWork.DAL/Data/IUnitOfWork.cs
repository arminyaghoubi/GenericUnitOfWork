using Microsoft.EntityFrameworkCore;

namespace GenericUnitOfWork.DAL.Data;

public interface IUnitOfWork<TContext>
    where TContext : DbContext
{
    TContext Context { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
