using System;
using System.Collections.Generic;
using System.Linq;

namespace Integrator.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity  
    {
        protected readonly IntegratorContext _context;

        public GenericRepository(IntegratorContext context)
        {
            _context = context;
        }
        
        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Delete(string id)
        {
            var entity = _context.Set<T>().Find(id);
            Delete(entity);
        }

        public IEnumerable<T> ListAll()
        {
            return _context.Set<T>().ToList();
        }
    }  
}