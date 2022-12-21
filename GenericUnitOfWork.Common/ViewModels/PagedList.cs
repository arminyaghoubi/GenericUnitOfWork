namespace GenericUnitOfWork.Common.ViewModels;

public class PagedList<TEntity> : IPagedList<TEntity>
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public IEnumerable<TEntity> Items { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => Math.Ceiling(TotalCount / PageSize * 1.0) > CurrentPage;
}
