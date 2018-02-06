using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LuizalabsEmployeeManager.Domain.Tests.Entities
{
    [TestClass]
    public class EmployeeTests
    {
        private string Name { get; set; }
        private Email Email { get; set; }
        private int Department { get; set; }

        public EmployeeTests()
        {
            Name = "Verner Estevam Pereira";
            Email = new Email("vernerpereira@gmail.com");
            Department = 1;
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Employee_Name_Empty()
        {
            var Employee = new Employee("", Email, Department);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Employee_Name_Null()
        {
            var Employee = new Employee(null, Email, Department);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Employee_Name_MaxLength()
        {
            var name = "Verner";
            while (name.Length < Employee.NameMaxLength + 1)
            {
                name = name + "123";
            }
            new Employee(name, Email, Department);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Employee_Email_Null()
        {
            var Employee = new Employee(Name, null, Department);
        }
    }
}
