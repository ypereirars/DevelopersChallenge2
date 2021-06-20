using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Repositories;
using XayahFinances.Domain.Interfaces.Services;

namespace XayahFinances.Services
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        public TransactionService(ITransactionRepository repository) : base(repository)
        {
        }
    }
}
