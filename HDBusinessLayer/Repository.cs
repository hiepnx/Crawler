using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HDBusinessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;
        protected DbContext context;

        public Repository(DbContext dataContext)
        {
            context = dataContext;
            DbSet = dataContext.Set<T>();
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            DbSet.Add(entity);

        }
        public void InsertRange(List<T> entities)
        {
            DbSet.AddRange(entities);
            
        }
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public void DeleteAll()
        {
            DbSet.RemoveRange(DbSet);
        }
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
            //var local = DbSet.Local.Where(predicate.Compile());
            //return local.Any()? local: DbSet.Where(predicate).ToArray();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
            
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        #endregion
    }
}
