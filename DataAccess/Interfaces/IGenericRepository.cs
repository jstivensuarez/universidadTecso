using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
