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

        public int Create(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Delete(int identificador)
        {
            throw new NotImplementedException();
        }

        public T Get(int identificador)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
