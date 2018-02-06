using LuizalabsEmployeeManager.Domain.Entities;
using LuizalabsEmployeeManager.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizalabsEmployeeManager.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly EfDbContext Context;

        public Repository(EfDbContext context)
        {
            Context = context;
        }

        private DbSet<TEntity> Entity { get { return Context.Set<TEntity>(); } }

        public void Add(TEntity obj)
        {
            obj.PersistDate = DateTime.Now;
            Entity.Add(obj);
        }
             
        public void Delete(int id)
        {
            Entity.Remove(Get(id));
        }

        public TEntity Get(int id)
        {
            return Entity.Find(id);
        }
        
        public IQueryable<TEntity> Get()
        {
            return Entity;
        }

        public IEnumerable<TEntity> Get(int pageSize, int page)
        {
            if (page > 0)
            {
                page = page - 1;
            }

            int offset = page > 0 ? page * pageSize : 0;

            IQueryable<TEntity> query = (from x
                                            in Entity
                                            orderby x.Id ascending
                                         select x);
            
            var res = query.Skip(offset);


            if (pageSize > 0)
                res = res.Take(pageSize);

            return res.ToList<TEntity>();            
        }

        public void Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
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
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        
    }
}
