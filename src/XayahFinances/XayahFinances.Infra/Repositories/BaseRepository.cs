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

        public abstract long Create(T entity);
        public abstract void Delete(long id);
        public abstract T Get(long id);
        public abstract IEnumerable<T> Get();
        public abstract void Update(T entity);
    }
}
