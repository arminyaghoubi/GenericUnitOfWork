using GenericUnitOfWork.BL.Services;
using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace GenericUnitOfWork.BL.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services) =>
        services.AddScoped<IBaseService<Publisher, short, PublisherViewModel>, PublisherService>();
}
