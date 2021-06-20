using System;
using System.Collections.Generic;
using System.Data;
using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Repositories;

namespace XayahFinances.Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly IDbConnection Connection;

        public BaseRepository(IDbConnection connection) => Connection = connection;

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

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
