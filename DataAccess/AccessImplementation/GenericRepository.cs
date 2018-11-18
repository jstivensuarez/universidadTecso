using DataAccess.exceptions;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.AccessImplementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        internal UniversidadContext _context;

        public GenericRepository(UniversidadContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al agregar la entidad", ex);
            }
            
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al eliminar la entidad", ex);
            }
            
        }

        public void Edit(T entity)
        {
            try
            {
               _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al editar la entidad", ex);
            }
           
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>().Where(predicate);
                return query;
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al buscar la entidad", ex);
            }
           
        }

        public T Find(int id)
        {
            try
            {
                T entity = _context.Set<T>().Find(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al buscar la entidad", ex);
            }
            
        }

        public virtual List<T> GetAll()
        {
            try
            {
                List<T> query = _context.Set<T>().ToList();
                return query;
            }
            catch (Exception ex)
            {
                throw new ExceptionData("error al obetener las entidades", ex);
            }
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
