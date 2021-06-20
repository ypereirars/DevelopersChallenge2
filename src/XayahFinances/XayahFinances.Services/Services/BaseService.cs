using System;
using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Repositories;
using XayahFinances.Domain.Interfaces.Services;

namespace XayahFinances.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected readonly IBaseRepository<T> Repository;

        public BaseService(IBaseRepository<T> repository) => Repository = repository;

        public long Create(T entity)
        {
            return Repository.Create(entity);
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }

        public T Get(long id)
        {
            return Repository.Get(id);
        }

        public System.Collections.Generic.IEnumerable<T> Get()
        {
            return Repository.Get();
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }
    }
}
