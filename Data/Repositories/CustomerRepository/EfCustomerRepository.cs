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
            entity.CreatedAt = DateTime.Now;
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
            return await _context.customers.Include(i => i.Address).ToListAsync();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _context.customers.Include(i => i.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Update(Customer entity)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(c => c.Id == entity.Id);
            customer.Name = entity.Name != default ? entity.Name : customer.Name;
            customer.Email = entity.Email != default ? entity.Email : customer.Email;
            customer.AddressId = entity.AddressId != default ? entity.AddressId : customer.AddressId;
            customer.UpdatedAt = DateTime.Now;
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<bool> Validate(Guid id)
        {
            return await _context.customers.AnyAsync(c => c.Id == id);
        }
    }
}