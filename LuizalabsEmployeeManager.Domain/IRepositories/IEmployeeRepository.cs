using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizalabsEmployeeManager.Domain.IRepositories
{
    public interface IEmployeeRepository
    {
        bool EmailExists(Email email, int employeeId);
        Employee Get(string name);
        Employee Get(Email email);
        Employee Get(int id);
        void Save(Employee employee);
        IEnumerable<Employee> Get(int pageSize, int page);
        void Delete(int id);
    }
}
