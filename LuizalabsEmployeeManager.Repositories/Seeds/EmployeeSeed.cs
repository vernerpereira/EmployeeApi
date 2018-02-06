using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.ValueObjects;
using System.Data.Entity.Migrations;

namespace LuizalabsEmployeeManager.Repositories.Seeds
{
    public class EmployeeSeed
    {
        public static void Seed(EfDbContext context)
        {
            context.Employees.AddOrUpdate(x => x.Name, 
                new Employee("Rodrigo Carvalho",new Email("rodrigo@luizalabs.com"), 1));
            context.Employees.AddOrUpdate(x => x.Name,
                new Employee("Renato Pedigoni", new Email("renato@luizalabs.com"), 2));
            context.Employees.AddOrUpdate(x => x.Name,
                new Employee("Thiago Catoto", new Email("catoto@luizalabs.com"), 3));
        }
    }
}
