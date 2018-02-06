using LuizalabsEmployeeManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizalabsEmployeeManager.Repositories.Tests.TestData
{
    public class DepartmentTempData
    {
        public static List<Department> Get()
        {
            return new List<Department> {
                new Department("IntegraCommerce") { Id = 1 },
                new Department("Digital Platform") { Id = 2 },
                new Department("Mobile") { Id=3 }
            };
        }
    }
}
