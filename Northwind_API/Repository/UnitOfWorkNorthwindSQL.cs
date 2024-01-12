using Northwind_API.Entities;

namespace Northwind_API.Repository
{
    public class UnitOfWorkNorthwindSQL : IUnitOfWorkNorthwind
    {
        private readonly NorthwindContext _context;
        private BaseRepositorySQL<Employee> _employeesRepository;
        private BaseRepositorySQL<Order> _ordersRepository;

        public UnitOfWorkNorthwindSQL(NorthwindContext context)
        {
            _context = context;
            _employeesRepository = new BaseRepositorySQL<Employee>(context);
            _ordersRepository = new BaseRepositorySQL<Order>(context);
        }

        public IRepository<Employee> EmployeesRepository
        {
            get { return _employeesRepository; }
        }

        public IRepository<Order> OrdersRepository
        {
            get { return _ordersRepository; }
        }
    }
}
