using Microsoft.AspNetCore.Mvc;
using Northwind_API.DTO;
using Northwind_API.Entities;
using Northwind_API.Repository;
using System.Net;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;
        private readonly NorthwindContext _dbContext;

        public OrderController()
        {
            _dbContext = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkNorthwindSQL(_dbContext);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<OrderDTO>>> GetAllOrders(int id)
        {
            Employee? employee = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            IList<Order> allOrders = await _unitOfWorkNorthwind.OrdersRepository.GetAllAsync();
            IEnumerable<Order> employeeOrders = allOrders.Where(o => o.EmployeeId == id);
            IList<OrderDTO> orderDTOs = employeeOrders.Select(o => OrderToDTO(o)).ToList();
            return Ok(orderDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> InsertOrder(OrderDTO orderDTO)
        {
            orderDTO.OrderId = 0;
            Order order = DtoToOrder(orderDTO);
            await _unitOfWorkNorthwind.OrdersRepository.InsertAsync(order);
            return Ok(orderDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<OrderDTO>> DeleteOrder(int idOrder)
        {
            Order order = await _unitOfWorkNorthwind.OrdersRepository.GetByIdAsync(idOrder);
            if(order == null)
            {
                return NotFound("Order not found");
            }
            else
            {
                await _unitOfWorkNorthwind.OrdersRepository.DeleteAsync(order);
                return Ok(order);
            }
        }

        [HttpPut] //update tous les attributs de l'objet contrairement au PATCH
        public async Task<ActionResult<OrderDTO>> UpdateOrder( OrderDTO orderDTO)
        {
            Order? order = await _unitOfWorkNorthwind.OrdersRepository.GetByIdAsync(orderDTO.OrderId);
            if(order == null )
            {
                return NotFound("Order not found");
            }
            else
            {
                //modifier manuellement le DTO car problème avec Core qui track l'objet
                order.OrderDate = orderDTO.OrderDate;
                await _unitOfWorkNorthwind.OrdersRepository.SaveAsync(order);
               // await _unitOfWorkNorthwind.OrdersRepository.SaveAsync(order, o => o.OrderId == orderDTO.OrderId);
                return Ok(order);
            }
        }

        private OrderDTO OrderToDTO(Order order) =>
            new OrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = (DateTime)order.OrderDate,
            };

        private static Order DtoToOrder(OrderDTO orderDTO) =>
            new Order
            {
                OrderId = orderDTO.OrderId,
                OrderDate = orderDTO.OrderDate,
            };
    }
}
