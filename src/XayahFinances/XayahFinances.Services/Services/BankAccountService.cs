using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Repositories;
using XayahFinances.Domain.Interfaces.Services;

namespace XayahFinances.Services
{
    public class BankAccountService : BaseService<BankAccount>, IBankAccountService
    {
        public BankAccountService(IBankAccountRepository repository) : base(repository)
        {
        }
    }
}
