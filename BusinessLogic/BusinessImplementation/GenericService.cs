using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.BusinessImplementation
{
    public class GenericService<T, S> : IGenericService<T, S> where T : class, new() where S: class
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
            repository.Add(mapper.Map<T>(entity));
        }

        public void Delete(S entity)
        {
            repository.Delete(mapper.Map<T>(entity));
        }

        public void Edit(S entity)
        {
            repository.Edit(mapper.Map<T>(entity));
        }

        public IQueryable<S> Find(Expression<Func<T, bool>> predicate)
        {
            return mapper.Map<IQueryable<S>>(repository.Find(predicate));
        }

        public List<S> GetAll()
        {
            var T = repository.GetAll();
            return mapper.Map<List<S>>(T);
        }
    }
}
