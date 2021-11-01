using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetByCustomerId(Guid id);
        Task<bool> ChangeStatus(Guid id, string status);
    }
}