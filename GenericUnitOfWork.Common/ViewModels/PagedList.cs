namespace GenericUnitOfWork.Common.ViewModels;

public class PagedList<TEntity> : IPagedList<TEntity>
{
    public int CurrentPage { get; }

    public int PageSize { get; }

    public int TotalCount { get; }

    public int TotalPages { get; }

    public IEnumerable<TEntity> Items { get; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => Math.Ceiling(TotalCount / PageSize * 1.0) > CurrentPage;

    public PagedList(IEnumerable<TEntity> entities, int currentPage, int pageSize)
    {
        if (entities is null) throw new ArgumentNullException();

        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = entities.Count();
        TotalPages = (int)Math.Ceiling(entities.Count() / (double)pageSize);
        Items = entities.Skip((currentPage - 1) * pageSize).Take(pageSize);
    }
}

public class PagedList<TEntity, TResult> : IPagedList<TResult>
{
    public int CurrentPage { get; }

    public int PageSize { get; }

    public int TotalCount { get; }

    public int TotalPages { get; }

    public IEnumerable<TResult> Items { get; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => Math.Ceiling(TotalCount / PageSize * 1.0) > CurrentPage;

    public PagedList(IEnumerable<TEntity> entities, Func<TEntity, TResult> selector, int currentPage, int pageSize)
    {
        if (entities is null) throw new ArgumentNullException();

        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = entities.Count();
        TotalPages = (int)Math.Ceiling(entities.Count() / (double)pageSize);
        Items = entities.Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .Select(selector);
    }
}
