using LuizalabsEmployeeManager.Domain.ValueObjects;
using LuizalabsEmployeeManager.Helpers;
using System;

namespace LuizalabsEmployeeManager.Domain.Entities
{
    public class Employee : EntityBase
    {
        public const int NameMaxLength = 128;
        public string Name { get; private set; }
        public Email Email { get; private set; }
        
        public int DepartmentId { get; private set; }
        public virtual Department Department { get; set; }

        protected Employee()
        {

        }

        public Employee(string name, Email email, int departmentId)
        {
            SetName(name);
            SetEmail(email);
            SetDepartmentId(departmentId);
            PersistDate = DateTime.Now;
        }

        private void SetDepartmentId(int departmentId)
        {
            DepartmentId = departmentId;
        }

        private void SetEmail(Email email)
        {
            if(email == null)
                throw new Exception("E-mail is required!");

            Email = email;
        }

        private void SetName(string name)
        {
            Guard.ForNullOrEmptyDefaultMessage(name, "Name");
            Guard.StringLength("Name", name, NameMaxLength);
            Name = name;
        }
    }
}
