using GenericUnitOfWork.BL.Services;
using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;

namespace GenericUnitOfWork.API.Controllers;

public class BookController : BaseController<Book, int, BookViewModel>
{
    public BookController(IBaseService<Book, int, BookViewModel> service) : base(service)
    {
    }
}