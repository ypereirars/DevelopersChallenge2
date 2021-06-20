using Dapper;
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
            var query = @"INSERT INTO transactions
                            (type, date, amount, description, bank_account_id)
                        OUTPUT INSERTED.ID
                        VALUES
                            (@Type, @Date, @Amount, @Description, @BankAccountId)";

            var id = Connection.QuerySingle<long>(query, entity);
            entity.Id = id;

            return id;
        }

        public override void Delete(long id)
        {
            Connection.Query(@"DELETE FROM transactions WHERE id = @id", new { id = id });
        }

        public override Transaction Get(long id)
        {
               var query = @"
                SELECT
                    TR.type as Type,
                    TR.date as Date,
                    TR.amount as AccountType,
                    TR.description as Description,
                    TR.bank_account_id as BankAccountId
                FROM
                    transactions TR
                WHERE TR.id = @id";

            return Connection.QuerySingle<Transaction>(query, param: new { id = id });
        }

        public override IEnumerable<Transaction> Get()
        {
            var query = @"
                SELECT
                    TR.type as Type,
                    TR.date as Date,
                    TR.amount as AccountType,
                    TR.description as Description,
                    TR.bank_account_id as BankAccountId
                FROM
                    transactions TR";

            return Connection.Query<Transaction>(query);
        }

        public override void Update(Transaction entity)
        {
            var query = @"
                UPDATE transactions 
                SET
                    type=@BankId,
                    date=@AccountNumber,
                    amount=AccountType,
                    description=Description,
                    bank_account_id=BankAccountId";

            Connection.Query(query);
        }
    }
}
