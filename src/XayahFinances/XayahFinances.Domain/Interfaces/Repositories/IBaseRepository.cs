using System.Collections.Generic;
using System.Data;

namespace XayahFinances.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T: Entities.Entity
    {
        int Create(T entidade);
        T Get(int identificador);
        IEnumerable<T> Get();
        void Update(T entidade);
        void Delete(int identificador);
    }
}
