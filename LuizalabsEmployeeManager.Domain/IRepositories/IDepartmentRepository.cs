using LuizalabsEmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizalabsEmployeeManager.Domain.IRepositories
{
    public interface IDepartmentRepository
    {
        bool NameExists(string name, int departmentId);
        Department Get(string name);
        Department Get(int id);
        void Save(Department employee);
    }
}
