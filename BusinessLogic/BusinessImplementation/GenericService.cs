using AutoMapper;
using BusinessLogic.exceptions;
using BusinessLogic.Interfaces;
using DataAccess.exceptions;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.BusinessImplementation
{
    public class GenericService<T, S> : IGenericService<T, S> 
        where T : class 
        where S: class
    {
        readonly IGenericRepository<T> repository;
        readonly IMapper mapper;
        public GenericService(IGenericRepository<T> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(S entity)
        {
            try
            {
                repository.Add(mapper.Map<T>(entity));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar agregar la entidad", ex);
            }
            
        }

        public void Delete(S entity)
        {
            try
            {
                repository.Delete(mapper.Map<T>(entity));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar eliminar la entidad", ex);
            }          
        }

        public void Edit(S entity)
        {
            try
            {
                repository.Edit(mapper.Map<T>(entity));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar editar la entidad", ex);
            }    
        }

        public IQueryable<S> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return mapper.Map<IQueryable<S>>(repository.Find(predicate));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar buscar la entidad", ex);
            }           
        }

        public S Find(int id)
        {
            try
            {
                return mapper.Map<S>(repository.Find(id));
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar buscar la entidad", ex);
            }
        }

        public List<S> GetAll()
        {
            try
            {
                var T = repository.GetAll();
                return mapper.Map<List<S>>(T);
            }
            catch (ExceptionData)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ExceptionBusiness("error al intentar obtener las entidades", ex);
            }           
        }
    }
}
