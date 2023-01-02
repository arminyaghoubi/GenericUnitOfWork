using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using GenericUnitOfWork.DAL.Data;
using GenericUnitOfWork.DAL.Repositories;
using System.Linq.Expressions;

namespace GenericUnitOfWork.BL.Services;

public class AuthorService : BaseService<Author, short, AuthorViewModel>
{
    public AuthorService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override async Task<AuthorViewModel?> GetByIdAsync(short key, CancellationToken cancellationToken = default)
    {
        var result = await Repository.GetByIdAsync(key, cancellationToken);
        if (result is null)
            return null;
        return new AuthorViewModel
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Description = result.Description
        };
    }

    public override async Task<AuthorViewModel?> GetFirstOrDefaultAsync(Expression<Func<Author, bool>> predicate = null, bool disableTracking = true, CancellationToken cancellationToken = default) =>
    await Repository.GetFirstOrDefaultAsync(
            a => new AuthorViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Description = a.Description,
                BookCount = a.Books.Count()
            },
            predicate,
            p => p.Books,
            true,
            false,
            cancellationToken);

    public override IPagedList<AuthorViewModel> GetPagedList(int page = 1, int pageSize = 20) =>
    Repository.GetPagedList(
            selector: a => new AuthorViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Description = a.Description,
                BookCount = a.Books.Count()
            },
            predicate: null,
            include: p => p.Books,
            order: p => p.Id,
            ascending: false,
            page: page,
            pageSize: pageSize);

    protected override void ChangeForUpdate(Author entity, AuthorViewModel viewModel)
    {
        entity.FirstName=viewModel.FirstName;
        entity.LastName=viewModel.LastName;
        entity.Description=viewModel.Description;
    }

    protected override Author ViewModelToModel(AuthorViewModel viewModel) =>
        new Author
        {
            Id = viewModel.Id,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Description = viewModel.Description,
        };
}