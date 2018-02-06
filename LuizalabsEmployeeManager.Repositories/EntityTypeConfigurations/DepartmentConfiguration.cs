using LuizalabsEmployeeManager.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace LuizalabsEmployeeManager.Repositories.EntityTypeConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(Department.NameMaxLength)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
               new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));
        }
    }
}
