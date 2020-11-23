using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acupunctuur.data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private AcupunctuurContext Context { get; set; }

        public Repository(AcupunctuurContext context)
        {
            Context = context;
        }

        public List<TEntity>GetAll()
        {
            return Context.Set<TEntity>().ToList(); 
        }

        public IQueryable <TEntity> Query()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
