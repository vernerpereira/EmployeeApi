using LuizalabsEmployeeManager.API.ViewModels;
using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.IRepositories;
using LuizalabsEmployeeManager.Domain.ValueObjects;
using LuizalabsEmployeeManager.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace LuizalabsEmployeeManager.API.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    public class EmployeeController : ApiController
    {
        private EfDbContext _context = new EfDbContext();
        /// <summary>
        /// Get paginated Employee
        /// </summary>
        /// <returns>Array of Employee</returns>
        public IHttpActionResult Get(int page_size, int page)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Repository<Employee>(_context));
            List<Employee> employees = employeeRepository.Get(page_size, page).ToList();
            return Ok(employees.Select(x => new EmployeeViewModel { Name = x.Name, Department = x.Department.Name, Email = x.Email.Address }));
            
        }

        /// <summary>
        /// Create new Employee
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns>Status of creation</returns>
        public IHttpActionResult Post([FromBody]EmployeeViewModel employee)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Repository<Employee>(_context));
            DepartmentRepository departmentRepository = new DepartmentRepository(new Repository<Department>(_context));
            Department department = departmentRepository.Get(employee.Department);
            if (department != null)
            {
                if (!employeeRepository.EmailExists(new Email(employee.Email), 0))
                {
                    Employee employeeToSave = new Employee(employee.Name, new Email(employee.Email), department.Id);
                    employeeRepository.Save(employeeToSave);
                    return Created("", new EmployeeViewModel { Name = employeeToSave.Name, Department = employeeToSave.Department.Name, Email = employeeToSave.Email.Address });
                }
                else
                {
                    return BadRequest("E-mail already exists!");
                }
            }
            else
            {
                return BadRequest("Invalid Department!");
            }
        }

        /// <summary>
        /// Delete an Employee
        /// </summary>
        /// <param name="id">Id of Employee</param>
        /// <returns>Status of deletion</returns>
        public IHttpActionResult Delete(int id)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(new Repository<Employee>(_context));
            employeeRepository.Delete(id);

            return Ok();
        }
    }
}
