using GenericUnitOfWork.BL.Services;
using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;

namespace GenericUnitOfWork.API.Controllers;

public class AuthorController : BaseController<Author, short, AuthorViewModel>
{
    public AuthorController(IBaseService<Author, short, AuthorViewModel> service) : base(service)
    {
    }
}