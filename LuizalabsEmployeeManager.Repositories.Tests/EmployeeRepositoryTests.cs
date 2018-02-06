using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.IRepositories;
using LuizalabsEmployeeManager.Repositories.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using LuizalabsEmployeeManager.Domain.ValueObjects;

namespace LuizalabsEmployeeManager.Repositories.Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly RepositoryList<Employee> _repository;

        public EmployeeRepositoryTests()
        {
            _repository = new RepositoryList<Employee>(EmployeeTestData.Get());
            _employeeRepository = new EmployeeRepository(_repository);
        }
        
        [TestMethod]
        public void EmployeeRepository_EmailExists_New_Employee()
        {
            var exists = _employeeRepository.EmailExists(new Email("rodrigo@luizalabs.com"), 0);
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void EmployeeRepository_EmailExists_Existent_Employee()
        {
            var exists = _employeeRepository.EmailExists(new Email("rodrigo@luizalabs.com"), 1);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void EmployeeRepository_Save_New_Employee()
        {
            var employee = new Employee("Verner Pereira", new Email("vernerpereira@gmail.com"), 1);

            var totalBeforeSave = _repository.Get().Count();
            _employeeRepository.Save(employee);
            var totalAfterSave = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalBeforeSave + 1, totalAfterSave);
        }

        [TestMethod]
        public void EmployeeRepository_Get_Id()
        {
            var employee = _repository.Get().FirstOrDefault();
            Assert.AreEqual(employee, _employeeRepository.Get(employee.Id));
        }

        [TestMethod]
        public void EmployeeRepository_Get_Name()
        {
            var employee = _repository.Get().FirstOrDefault();
            Assert.AreEqual(employee, _employeeRepository.Get(employee.Name));
        }

        [TestMethod]
        public void EmployeeRepository_Get_Email()
        {
            var employee = _repository.Get().FirstOrDefault();
            Assert.AreEqual(employee, _employeeRepository.Get(employee.Email));
        }
    }
}
