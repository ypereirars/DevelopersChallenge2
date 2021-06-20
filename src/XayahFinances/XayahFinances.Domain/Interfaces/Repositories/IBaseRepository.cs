using System.Collections.Generic;

namespace XayahFinances.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T: Entities.Entity
    {
        long Create(T entity);
        T Get(long id);
        IEnumerable<T> Get();
        void Update(T entity);
        void Delete(long id);
    }
}
