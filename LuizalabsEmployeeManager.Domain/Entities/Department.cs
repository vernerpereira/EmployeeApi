using LuizalabsEmployeeManager.Helpers;
using System;
using System.Collections.Generic;

namespace LuizalabsEmployeeManager.Domain.Entities
{
    public class Department : EntityBase
    {
        public const int NameMaxLength = 128;
        public string Name { get; private set; }

        public ICollection<Employee> Employees { get; set; }

        //Entity Framework
        protected Department()
        {
            Employees = new List<Employee>();
        }

        public Department(string name)
        {
            SetName(name);
            PersistDate = DateTime.Now;
        }

        private void SetName(string name)
        {
            Guard.ForNullOrEmptyDefaultMessage(name, "Name");
            Guard.StringLength("Name", name, NameMaxLength);

            Name = name;
        }
    }
}
