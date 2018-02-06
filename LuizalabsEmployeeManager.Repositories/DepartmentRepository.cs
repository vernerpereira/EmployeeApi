using LuizalabsEmployeeManager.Domain.IRepositories;
using System.Linq;
using LuizalabsEmployeeManager.Domain.Entities;
using System;

namespace LuizalabsEmployeeManager.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IRepository<Department> _departmentRepository;
        
        public DepartmentRepository(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department Get(int id)
        {
            return _departmentRepository.Get(id);
        }

        public Department Get(string name)
        {
            return _departmentRepository.Get().FirstOrDefault(x => x.Name == name);
        }

        public bool NameExists(string name, int departmentId)
        {
            return _departmentRepository.Get().Any(x => x.Name == name
                                                    && x.Id != departmentId);
        }

        public void Save(Department department)
        {
            _departmentRepository.AddOrUpdate(department);
            _departmentRepository.Commit();
        }
    }
}
