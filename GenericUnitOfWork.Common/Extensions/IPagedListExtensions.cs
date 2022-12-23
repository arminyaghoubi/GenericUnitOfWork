using GenericUnitOfWork.Common.ViewModels;

namespace GenericUnitOfWork.Common.Extensions;

public static class IPagedListExtensions
{
    public static IPagedList<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> entities, int currentPage, int pageSize) =>
        new PagedList<TEntity>(entities, currentPage, pageSize);

    public static IPagedList<TResult> ToPagedList<TEntity, TResult>(this IEnumerable<TEntity> entities,
        Func<TEntity, TResult> selector,
        int currentPage, 
        int pageSize) =>
        new PagedList<TEntity, TResult>(entities,selector,currentPage, pageSize);
}
