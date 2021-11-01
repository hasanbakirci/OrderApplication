using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> Validate(Guid id);
    }
}