using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizalabsEmployeeManager.Repositories
{
    public class RepositoryList<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly List<TEntity> _list;
        public bool Commited;

        public RepositoryList(List<TEntity> list)
        {
            _list = list;
            Commited = false;
        }

        public void Add(TEntity obj)
        {
            obj.PersistDate = DateTime.Now;
            _list.Add(obj);
        }

        public void AddAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Add(entity);
        }

        public void Update(TEntity obj)
        {
            _list[_list.IndexOf(Get(obj.Id))] = obj;
        }

        public void AddOrUpdate(TEntity obj)
        {
            if (obj.Id > 0)
                Update(obj);
            else
                Add(obj);
        }

        public void Commit()
        {
            Commited = true;
        }

        public void Delete(int id)
        {
            _list.Remove(Get(id));
        }

        public IQueryable<TEntity> Get()
        {
            return _list.AsQueryable();
        }

        public TEntity Get(int id)
        {
            return _list.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> Get(int pageSize, int page)
        {
            if (page > 0)
            {
                page = page - 1;
            }

            int offset = page > 0 ? page * pageSize : 0;
            
            var res = _list.Skip(offset);
            
            if (pageSize > 0)
                res = res.Take(pageSize);

            return res.ToList<TEntity>();
        }
    }
}
