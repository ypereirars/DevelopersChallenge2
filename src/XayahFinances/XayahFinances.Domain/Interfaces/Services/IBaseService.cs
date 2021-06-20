using System.Collections.Generic;

namespace XayahFinances.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T: Entities.Entity
    {
        int Create(T entidade);
        T Get(int identificador);
        IEnumerable<T> Get();
        void Update(T entidade);
        void Delete(int identificador);
    }
}
