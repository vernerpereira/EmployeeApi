using LuizalabsEmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizalabsEmployeeManager.Domain.ValueObjects;

namespace LuizalabsEmployeeManager.Repositories.Tests.TestData
{
    public class EmployeeTestData
    {
        public static List<Employee> Get()
        {
            return new List<Employee> {
                new Employee("Rodrigo Carvalho", new Email("rodrigo@luizalabs.com"), 1) { Id=1, Department = new Department("IntegraCommerce") { Id = 1 } },
                new Employee("Renato Pedigoni", new Email("renato@luizalabs.com"), 2) { Id = 2, Department = new Department("Digital Platform") { Id = 2 } },
                new Employee("Thiago Catoto", new Email("catoto@luizalabs.com"), 3) { Id = 3, Department = new Department("Mobile") { Id=3 } }
            };
        }
    }
}
