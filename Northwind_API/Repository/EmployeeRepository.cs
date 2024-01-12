using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using System.Linq.Expressions;

//VERSION Simple sans UnitOfWork
namespace Northwind_API.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly NorthwindContext _context = new NorthwindContext();

        public Task DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();

        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Employee entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Employee entity cannot be null");
            }

            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }

        public Task<bool?> SaveAsync(Employee entity, Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Employee>> SearchForAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
