using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.OrderRepository
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly OrderApplicationDbContext _context;

        public EfOrderRepository(OrderApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangeStatus(Guid id, string status)
        {
            var order = await _context.orders.SingleOrDefaultAsync(o => o.Id == id);
            order.Status = status;
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<Guid> Create(Order entity)
        {
            _context.orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var order = await _context.orders.SingleOrDefaultAsync(o => o.Id == id);
            _context.orders.Remove(order);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.orders.ToListAsync();
        }

        public async Task<Order> Get(Guid id)
        {
            return await _context.orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(Guid id)
        {
            return await _context.orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<bool> Update(Order entity)
        {
            _context.orders.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }
    }
}