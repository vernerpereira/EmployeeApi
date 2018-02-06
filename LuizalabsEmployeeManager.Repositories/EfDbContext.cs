using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Repositories.EntityTypeConfigurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LuizalabsEmployeeManager.Repositories
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("EfDbContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new EmployeeConfigurations());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
        }
    }
}
