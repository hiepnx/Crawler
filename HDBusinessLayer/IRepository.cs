using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HDBusinessLayer
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void InsertRange(List<T> entities);
        void Delete(T entity);
        void DeleteAll();
        void SaveChanges();
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();

        T GetById(int id);
    }
}
