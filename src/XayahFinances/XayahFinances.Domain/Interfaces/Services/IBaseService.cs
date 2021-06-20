using System.Collections.Generic;

namespace XayahFinances.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T: Entities.Entity
    {
        long Create(T entity);
        T Get(long id);
        IEnumerable<T> Get();
        void Update(T entity);
        void Delete(long id);
    }
}
