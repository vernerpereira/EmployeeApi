using LuizalabsEmployeeManager.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LuizalabsEmployeeManager.Domain.Tests.Entities
{
    [TestClass]
    public class DepartmentTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Department_Empty()
        {
            var department = new Department("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Department_Null()
        {
            var department = new Department(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Department_MaxLength()
        {
            var name = "HR";
            while (name.Length < Department.NameMaxLength + 1)
            {
                name = name + "123";
            }
            new Department(name);
        }
    }
}
