using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using System.Linq.Expressions;

//VERSION Simple sans UnitOfWork

namespace Northwind_API.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly NorthwindContext _context = new NorthwindContext();

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveAsync(Order entity, Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> SearchForAsync(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

