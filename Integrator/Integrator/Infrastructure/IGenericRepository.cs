using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Integrator.Infrastructure
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T GetById(string id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);
        IEnumerable<T> ListAll();
    }
}