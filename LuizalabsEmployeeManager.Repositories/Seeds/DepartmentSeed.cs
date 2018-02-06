using LuizalabsEmployeeManager.Domain.Entities;
using System.Data.Entity.Migrations;

namespace LuizalabsEmployeeManager.Repositories.Seeds
{
    public class DepartmentSeed
    {
        public static void Seed(EfDbContext context)
        {
            context.Departments.AddOrUpdate(x => x.Name, new Department("IntegraCommerce"));
            context.Departments.AddOrUpdate(x => x.Name, new Department("Digital Platform"));
            context.Departments.AddOrUpdate(x => x.Name, new Department("Mobile"));
        }
    }
}
