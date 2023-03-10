namespace GenericUnitOfWork.Common.ViewModels;

public interface IPagedList<TEntity>
{
    int CurrentPage { get; }
    int PageSize { get; }
    int TotalCount { get; }
    int TotalPages { get; }
    IEnumerable<TEntity> Items { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}
