using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Repositories
{
    public interface IRepository<T> where T: IEntity,new()
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Guid id);
        Task<Guid> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}