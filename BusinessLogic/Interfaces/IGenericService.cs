using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IGenericService<T, S> where T: class, new() where S : class
    {
        List<S> GetAll();
        IQueryable<S> Find(Expression<Func<T, bool>> predicate);
        void Add(S entity);
        void Delete(S entity);
        void Edit(S entity);
    }
}
