using GenericUnitOfWork.BL.Services;
using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace GenericUnitOfWork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TEntity, TKey, TResult> : ControllerBase
        where TEntity : BaseModel<TKey>
        where TResult : class
{
    private readonly IBaseService<TEntity, TKey, TResult> _service;

    public BaseController(IBaseService<TEntity, TKey, TResult> service)
    {
        _service = service;
    }

    [HttpGet]
    public IPagedList<TResult> GetPagedListAsync() => _service.GetPagedList();

    [HttpGet("{id}")]
    public async Task<TResult?> GetAsync(TKey id, CancellationToken cancellationToken) =>
        await _service.GetByIdAsync(id, cancellationToken);

    [HttpPost]
    public async Task<TEntity> AddAsync(TResult newItem, CancellationToken cancellationToken) =>
        await _service.InsertAsync(newItem, cancellationToken);

    [HttpPut("{id}")]
    public async Task UpdateAsync(TKey id, TResult viewModel, CancellationToken cancellationToken) =>
        await _service.UpdateAsync(id, viewModel, cancellationToken);


    [HttpDelete("{id}")]
    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken) =>
        await _service.DeleteAsync(id, cancellationToken);
}
