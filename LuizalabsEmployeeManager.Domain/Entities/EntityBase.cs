using System;

namespace LuizalabsEmployeeManager.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime PersistDate { get; set; }
    }
}
