using Northwind_API.Entities;

namespace Northwind_API.Repository
{
    //Couche qui communique avec Repository
    public interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }
        IRepository<Order> OrdersRepository { get; }
    }
}
