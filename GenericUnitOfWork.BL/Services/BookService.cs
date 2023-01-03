using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using GenericUnitOfWork.DAL.Data;
using System.Linq.Expressions;

namespace GenericUnitOfWork.BL.Services;

public class BookService : BaseService<Book, int, BookViewModel>
{
    public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override async Task<BookViewModel?> GetByIdAsync(int key, CancellationToken cancellationToken = default)
    {
        var result = await Repository.GetByIdAsync(key, cancellationToken);
        if (result is null)
            return null;
        return new BookViewModel
        {
            Id = result.Id,
            Title = result.Title,
            ISBN = result.ISBN,
            ImagePath = result.ImagePath,
            Pages = result.Pages,
            PrintYear = result.PrintYear,
            AuthorId = result.AuthorId,
            PublisherId = result.PublisherId
        };
    }

    public override async Task<BookViewModel?> GetFirstOrDefaultAsync(Expression<Func<Book, bool>> predicate = null, bool disableTracking = true, CancellationToken cancellationToken = default) =>
    await Repository.GetFirstOrDefaultAsync(
            b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                ImagePath = b.ImagePath,
                Pages = b.Pages,
                PrintYear = b.PrintYear,
                AuthorId = b.AuthorId,
                PublisherId = b.PublisherId,
                AuthorFirstName = b.Author.FirstName,
                AuthorLastName = b.Author.LastName,
                PublisherTitle = b.Publisher.Title
            },
            predicate,
            b => new { b.Author, b.Publisher },
            true,
            false,
            cancellationToken);

    public override IPagedList<BookViewModel> GetPagedList(int page = 1, int pageSize = 20) =>
    Repository.GetPagedList(
            selector: b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                ImagePath = b.ImagePath,
                Pages = b.Pages,
                PrintYear = b.PrintYear,
                AuthorId = b.AuthorId,
                PublisherId = b.PublisherId,
                AuthorFirstName = b.Author.FirstName,
                AuthorLastName = b.Author.LastName,
                PublisherTitle = b.Publisher.Title
            },
            predicate: null,
            include: b => new { b.Author, b.Publisher },
            order: p => p.Id,
            ascending: false,
            page: page,
            pageSize: pageSize);

    protected override void ChangeForUpdate(Book entity, BookViewModel viewModel)
    { 
        entity.Id = viewModel.Id;
        entity.Title = viewModel.Title;
        entity.ImagePath = viewModel.ImagePath;
        entity.ISBN = viewModel.ISBN;
        entity.Pages = viewModel.Pages;
        entity.PrintYear = viewModel.PrintYear;
        entity.AuthorId = viewModel.AuthorId;
        entity.PublisherId = viewModel.PublisherId;
    }

    protected override Book ViewModelToModel(BookViewModel viewModel) =>
    new Book
    {
        Id = viewModel.Id,
        Title = viewModel.Title,
        ImagePath = viewModel.ImagePath,
        ISBN = viewModel.ISBN,
        Pages = viewModel.Pages,
        PrintYear = viewModel.PrintYear,
        AuthorId = viewModel.AuthorId,
        PublisherId = viewModel.PublisherId
    };
}
