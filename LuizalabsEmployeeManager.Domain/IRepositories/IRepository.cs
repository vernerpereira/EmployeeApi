using LuizalabsEmployeeManager.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LuizalabsEmployeeManager.Domain.IRepositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity obj);
        void Delete(int id);

        TEntity Get(int id);
        IQueryable<TEntity> Get();
        IEnumerable<TEntity> Get(int pageSize, int page);
        void Update(TEntity obj);

        void Commit();

        void AddOrUpdate(TEntity obj);
    }
}
