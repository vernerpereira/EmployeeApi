namespace LuizalabsEmployeeManager.Repositories.Migrations
{
    using Seeds;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LuizalabsEmployeeManager.Repositories.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LuizalabsEmployeeManager.Repositories.EfDbContext context)
        {
            DepartmentSeed.Seed(context);
            EmployeeSeed.Seed(context);
        }
    }
}
