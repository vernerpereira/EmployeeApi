using LuizalabsEmployeeManager.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.ValueObjects;

namespace LuizalabsEmployeeManager.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeRepository(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Commit();
        }

        public bool EmailExists(Email email, int employeeId)
        {
            return _employeeRepository.Get().Any(x => x.Email.Address == email.Address
                                                    && x.Id != employeeId);
        }

        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public Employee Get(Email email)
        {
            return _employeeRepository.Get().FirstOrDefault(x => x.Email.Address == email.Address);
        }

        public Employee Get(string name)
        {
            return _employeeRepository.Get().FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Employee> Get(int pageSize, int page)
        {
            return _employeeRepository.Get(pageSize, page);
        }

        public void Save(Employee employee)
        {
            _employeeRepository.AddOrUpdate(employee);
            _employeeRepository.Commit();
        }
    }
}
