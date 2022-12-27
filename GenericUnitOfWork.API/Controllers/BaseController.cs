using GenericUnitOfWork.Common.Models;
using GenericUnitOfWork.Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericUnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TKey, TResult> : ControllerBase
        where TEntity : BaseModel<TKey>
        where TResult : class
    {
        [HttpGet]
        public async Task<IPagedList<TResult>> GetPagedListAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<TResult> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<TResult> AddAsync(TResult newItem)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
