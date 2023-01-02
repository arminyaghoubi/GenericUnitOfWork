using GenericUnitOfWork.BL.Services;
using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;

namespace GenericUnitOfWork.API.Controllers;

public class PublisherController : BaseController<Publisher, short, PublisherViewModel>
{
    public PublisherController(IBaseService<Publisher, short, PublisherViewModel> service) : base(service)
    {
    }
}
