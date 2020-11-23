using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acupunctuur.data
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public IQueryable<T> Query();
        public void Delete(T entity);
        public void Add(T entity);
        public void Update(T entity);
        int SaveChanges();
    }
}
