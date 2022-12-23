using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUnitOfWork.DAL.Repositories;

public interface IRepositoryFactory
{
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class;
}
