using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Integrator.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity  
    {
        protected readonly IntegratorContext Context;
        private DbSet<T> dbSet;

        public GenericRepository(IntegratorContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }
        
        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(string id)
        {
            var entity = dbSet.Find(id);
            Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
    }  
}