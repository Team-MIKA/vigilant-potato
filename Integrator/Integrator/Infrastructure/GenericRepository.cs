using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Integrator.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity  
    {
        protected readonly IntegratorContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(IntegratorContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(string id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }  
}