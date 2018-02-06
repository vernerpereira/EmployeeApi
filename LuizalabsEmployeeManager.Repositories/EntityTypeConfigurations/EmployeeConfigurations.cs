using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace LuizalabsEmployeeManager.Repositories.EntityTypeConfigurations
{
    public class EmployeeConfigurations : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfigurations()
        {
            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(Employee.NameMaxLength);

            Property(x => x.Email.Address)
                .HasColumnName("Email")
                .HasMaxLength(Email.AddressMaxLength)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
               new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true }));

            Property(x => x.DepartmentId)
                .HasColumnName("DepartmentId");

            HasRequired(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}
