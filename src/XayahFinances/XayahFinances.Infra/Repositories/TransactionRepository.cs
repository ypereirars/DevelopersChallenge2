using System.Collections.Generic;
using System.Data;
using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Repositories;

namespace XayahFinances.Infra.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IDbConnection connection) : base(connection)
        {
        }

        public override long Create(Transaction entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Transaction Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Transaction> Get()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
