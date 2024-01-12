using Microsoft.AspNetCore.Mvc;
using Northwind_API.DTO;
using Northwind_API.Entities;
using Northwind_API.Repository;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Utiliser l'attribut _employeeRepository c'est la version moche,
        // car le fait d'accéder à la couche Repository direct depuis le Controller
        // ça craint, ça crée une dépendance.
        // Préférez passer par le pattern UnitOfWork qui a une interface qui consiste
        // a une nouvelle couche pour avoir une belle structure d'architecture

        // private EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;
        private readonly NorthwindContext _dbContext;

        public EmployeeController()
        {
            _dbContext = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkNorthwindSQL(_dbContext);
        }

        /*        [HttpGet("employees")]
                public async Task<IList<EmployeeDTO>> GetAllEmployees()
                {
                    var employees = await _employeeRepository.GetAllAsync();
                    var employeeDTOs = employees.Select(employee => new EmployeeDTO
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                    }).ToList();
                    return employeeDTOs;
                }*/

        [HttpGet]
        public async Task<IList<EmployeeDTO>> GetEmployeesAsync()
        {
            IList<Employee> liste = await _unitOfWorkNorthwind.EmployeesRepository.GetAllAsync();

            //transforme la liste d'employée de la db en DTO pour 
            // ne pas donner des accès aux attributs qu'on veut pas
            // depuis le front
            return liste.Select(e => EmployeeToDTO(e)).ToList();
        }

        [HttpPost]
        public async Task InsertEmployeeAsync(EmployeeDTO employeDTO)
        {
            employeDTO.EmployeeId = 0;
            Employee e = DTOToEmployee(employeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.InsertAsync(e);
        }

        [HttpPut]
        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee e = DTOToEmployee(employeeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.SaveAsync(e);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            Employee? emp = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(id);
            return emp == null ? NotFound() : Ok(EmployeeToDTO(emp));
        }


        private static EmployeeDTO EmployeeToDTO(Employee emp) =>
            new EmployeeDTO
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };

        private static Employee DTOToEmployee(EmployeeDTO emp) =>
           new Employee
           {
               EmployeeId = emp.EmployeeId,
               LastName = emp.LastName,
               FirstName = emp.FirstName,
               BirthDate = emp.BirthDate,
               HireDate = emp.HireDate,
               Title = emp.Title,
               TitleOfCourtesy = emp.TitleOfCourtesy
           };


    }
}
