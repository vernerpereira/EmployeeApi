using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.IRepositories;
using LuizalabsEmployeeManager.Repositories.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LuizalabsEmployeeManager.Repositories.Tests
{
    [TestClass]
    public class DepartmentRepositoryTests
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly RepositoryList<Department> _repository;

        public DepartmentRepositoryTests()
        {
            _repository = new RepositoryList<Department>(DepartmentTempData.Get());
            _departmentRepository = new DepartmentRepository(_repository);
        }

        [TestMethod]
        public void DepartmentRepository_NameExists_New_Department()
        {
            var exists = _departmentRepository.NameExists("Mobile", 0);
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void DepartmentRepository_NameExists_Existent_Department()
        {
            var exists = _departmentRepository.NameExists("Mobile", 3);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void DepartmentRepository_Save_New_Department()
        {
            var department = new Department("HR");

            var totalBeforeSave = _repository.Get().Count();
            _departmentRepository.Save(department);
            var totalAfterSave = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalBeforeSave + 1, totalAfterSave);
        }

        [TestMethod]
        public void DepartmentRepository_Get_Id()
        {
            var department = _repository.Get().FirstOrDefault();
            Assert.AreEqual(department, _departmentRepository.Get(department.Id));
        }

        [TestMethod]
        public void DepartmentRepository_Get_Name()
        {
            var department = _repository.Get().FirstOrDefault();
            Assert.AreEqual(department, _departmentRepository.Get(department.Name));
        }
    }
}
