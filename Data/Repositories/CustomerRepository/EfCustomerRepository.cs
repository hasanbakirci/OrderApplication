using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.CustomerRepository
{
    public class EfCustomerRepository : ICustomerRepository
    {
        private readonly OrderApplicationDbContext _context;

        public EfCustomerRepository(OrderApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Customer entity)
        {
            _context.customers.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var customer = await _context.customers.SingleOrDefaultAsync(c => c.Id == id);
            _context.Remove(customer);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.customers.ToListAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            return await _context.customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Update(Customer entity)
        {
            _context.customers.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<bool> Validate(Guid id)
        {
            return await _context.customers.AnyAsync(c => c.Id == id);
        }
    }
}