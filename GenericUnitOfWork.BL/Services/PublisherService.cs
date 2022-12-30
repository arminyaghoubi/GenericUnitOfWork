using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using GenericUnitOfWork.DAL.Data;
using System.Linq.Expressions;

namespace GenericUnitOfWork.BL.Services;

public class PublisherService : BaseService<Publisher, short, PublisherViewModel>
{
    public PublisherService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override async Task<PublisherViewModel?> GetByIdAsync(short key, CancellationToken cancellationToken = default)
    {
        var result= await Repository.GetByIdAsync(key, cancellationToken);
        if (result is null)
            return null;
        return new PublisherViewModel
        {
            Id = result.Id,
            Title = result.Title,
        };
    }

    public override async Task<PublisherViewModel?> GetFirstOrDefaultAsync(Expression<Func<Publisher, bool>> predicate = null, bool disableTracking = true, CancellationToken cancellationToken = default) =>
        await Repository.GetFirstOrDefaultAsync(
            p => new PublisherViewModel
            {
                Id = p.Id,
                Title = p.Title,
                BookCount = p.Books.Count()
            },
            predicate,
            p => p.Books,
            true,
            false,
            cancellationToken);

    public override IPagedList<PublisherViewModel> GetPagedList(int page = 1, int pageSize = 20) =>
        Repository.GetPagedList(
            selector: p => new PublisherViewModel
            {
                Id = p.Id,
                Title = p.Title,
                BookCount = p.Books.Count()
            },
            predicate: null,
            include: p => p.Books,
            order: p => p.Id,
            ascending: false,
            page: page,
            pageSize: pageSize);

    protected override void ChangeForUpdate(Publisher entity, PublisherViewModel viewModel)
    {
        entity.Title = viewModel.Title;
    }

    protected override Publisher ViewModelToModel(PublisherViewModel viewModel) =>
        new Publisher
        {
            Id = viewModel.Id,
            Title = viewModel.Title
        };
}